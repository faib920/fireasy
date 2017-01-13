// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using System;
using System.Linq.Expressions;
using System.Web;

namespace Fireasy.Web.UI
{
    /// <summary>
    /// 提供 HTML 呈现的类。
    /// </summary>
    public class HtmlHelper : IHtmlString
    {
        private class HtmlHelperScope : Scope<HtmlHelperScope>
        {
            internal HtmlHelperScope()
            {
                Instance = new HtmlHelper();
            }

            internal HtmlHelper Instance { get; set; }

            protected override void Dispose(bool disposing)
            {
                Instance = null;
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// 获取默认实例。
        /// </summary>
        public static HtmlHelper Default
        {
            get
            {
                using(var s = new HtmlHelperScope())
                {
                    return s.Instance;
                }
            }
        }

        /// <summary>
        /// 获取 HTML 构造器。
        /// </summary>
        public TagBuilder Builder { get; private set; }

        /// <summary>
        /// 重新设置当前的 <see cref="TagBuilder"/> 对象。
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void ResetBuilder(string tag, string id, string name = null)
        {
            Builder = new TagBuilder(tag, id, name);
        }

        /// <summary>
        /// 使用前缀检查来设置当前的 <see cref="TagBuilder"/> 对象。
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="prefix">前缀。</param>
        /// <param name="exp">表达式。</param>
        public void ResetBuilderWithCheck(string tag, string prefix, string exp)
        {
            //如果以前缀开始
            if (exp.Length > prefix.Length && exp.StartsWith(prefix))
            {
                Builder = new TagBuilder(tag, exp, exp.Substring(prefix.Length));
            }
            else
            {
                Builder = new TagBuilder(tag, string.Concat(prefix, exp), exp);
            }
        }

        /// <summary>
        /// 使当前的元素成为不可用。
        /// </summary>
        /// <returns></returns>
        public HtmlHelper Disable()
        {
            AddAttribute("disabled", "disabled");
            return this;
        }

        /// <summary>
        /// 使当前的元素成为只读。
        /// </summary>
        /// <returns></returns>
        public HtmlHelper Readonly()
        {
            AddAttribute("readonly", "readonly");
            AddClass("readonly");
            return this;
        }

        /// <summary>
        /// 为元素添加一个属性。
        /// </summary>
        /// <param name="attributeName">属性名称。</param>
        /// <param name="value">属性的值。</param>
        /// <returns></returns>
        public HtmlHelper AddAttribute(string attributeName, string value)
        {
            Builder.AddAttribute(attributeName, value);
            return this;
        }

        /// <summary>
        /// 移除元素的一个属性。
        /// </summary>
        /// <param name="attributeName">属性名称。</param>
        /// <returns></returns>
        public HtmlHelper RemoveAttribute(string attributeName)
        {
            Builder.RemoveAttribute(attributeName);
            return this;
        }

        /// <summary>
        /// 为元素添加一个类。
        /// </summary>
        /// <param name="className">类的名称。</param>
        /// <returns></returns>
        public HtmlHelper AddClass(string className)
        {
            Builder.AddClass(className);
            return this;
        }

        /// <summary>
        /// 移除元素的一个类。
        /// </summary>
        /// <param name="className">类的名称。</param>
        /// <returns></returns>
        public HtmlHelper RemoveClass(string className)
        {
            Builder.RemoveClass(className);
            return this;
        }

        /// <summary>
        /// 为元素添加一个样式。
        /// </summary>
        /// <param name="styleName">样式名称。</param>
        /// <param name="value">样式的值。</param>
        /// <returns></returns>
        public HtmlHelper AddStyle(string styleName, string value)
        {
            Builder.AddStyle(styleName, value);
            return this;
        }

        /// <summary>
        /// 设置样式。
        /// </summary>
        /// <param name="style"></param>
        public HtmlHelper Style(string style)
        {
            Builder.Style(style);
            return this;
        }

        /// <summary>
        /// 设置属性。
        /// </summary>
        /// <param name="attrs">表示 attribute 的键值对。</param>
        /// <returns></returns>
        public HtmlHelper Attr(object attrs)
        {
            if (attrs == null)
            {
                return this;
            }

            foreach (var prop in attrs.GetType().GetProperties())
            {
                var value = prop.GetValue(attrs, null);
                if (value == null)
                {
                    continue;
                }

                Builder.AddAttribute(prop.Name, value.ToString());
            }

            return this;
        }

        /// <summary>
        /// 移除元素的一个样式。
        /// </summary>
        /// <param name="styleName">样式名称。</param>
        /// <returns></returns>
        public HtmlHelper RemoveStyle(string styleName)
        {
            Builder.RemoveStyle(styleName);
            return this;
        }

        /// <summary>
        /// 返回 Html 编码的字符串。
        /// </summary>
        /// <returns></returns>
        public virtual string ToHtmlString()
        {
            return Builder.Create(this);
        }

        /// <summary>
        /// 输出构造的字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToHtmlString();
        }

    }

    /// <summary>
    /// 提供基于数据模型的 HTML 呈现。
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class HtmlHelper<TModel> : HtmlHelper
    {
    }
}
