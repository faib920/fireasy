// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using Fireasy.Common.Extensions;
using System.Collections.Generic;
using System.Text;

namespace Fireasy.Web.UI
{
    /// <summary>
    /// 用于构造 HTML 的元素。无法继承此类。
    /// </summary>
    public sealed class TagBuilder
    {
        private Dictionary<string, string> attributes = new Dictionary<string, string>();
        private Dictionary<string, string> styles = new Dictionary<string, string>();
        private List<string> classes = new List<string>();
        private string innerHtml;
        private string tag;

        /// <summary>
        /// 初始化 <see cref="TagBuilder"/> 类的新实例。
        /// </summary>
        /// <param name="tag">元素的名称。</param>
        /// <param name="id">元素的 id 属性。</param>
        /// <param name="name">元素的 name 属性。</param>
        public TagBuilder(string tag, string id, string name)
        {
            Guard.ArgumentNull(tag, "tag");
            Guard.ArgumentNull(id, "id");

            this.tag = tag;
            AddAttribute("id", id);

            if (!string.IsNullOrEmpty(name))
            {
                AddAttribute("name", name);
            }
        }

        /// <summary>
        /// 获取或设置是否以 &lt;/TAG&gt; 结束元素。
        /// </summary>
        public bool TagClosed { get; set; }

        /// <summary>
        /// 加入一个属性。
        /// </summary>
        /// <param name="attributeName">属性名称。</param>
        /// <param name="value">属性的值。</param>
        public void AddAttribute(string attributeName, string value)
        {
            attributes.AddOrReplace(attributeName, value);
        }

        /// <summary>
        /// 移除一个属性。
        /// </summary>
        /// <param name="attributeName">属性名称。</param>
        public void RemoveAttribute(string attributeName)
        {
            if (attributes.ContainsKey(attributeName))
            {
                attributes.Remove(attributeName);
            }
        }

        /// <summary>
        /// 加入一个类。
        /// </summary>
        /// <param name="className">类的名称。</param>
        public void AddClass(string className)
        {
            if (!classes.Contains(className))
            {
                classes.Add(className);
            }
        }

        /// <summary>
        /// 移除一个类。
        /// </summary>
        /// <param name="className">类的名称。</param>
        public void RemoveClass(string className)
        {
            if (classes.Contains(className))
            {
                classes.Remove(className);
            }
        }

        /// <summary>
        /// 加入一个样式。
        /// </summary>
        /// <param name="styleName">样式的名称。</param>
        /// <param name="value">样式的值。</param>
        public void AddStyle(string styleName, string value)
        {
            styles.AddOrReplace(styleName, value);
        }

        /// <summary>
        /// 设置样式。
        /// </summary>
        /// <param name="style"></param>
        public void Style(string style)
        {
            styles.AddOrReplace("~", style);
        }

        /// <summary>
        /// 移除一个样式。
        /// </summary>
        /// <param name="styleName">样式的名称。</param>
        public void RemoveStyle(string styleName)
        {
            if (styles.ContainsKey(styleName))
            {
                styles.Remove(styleName);
            }
        }

        /// <summary>
        /// 生成字符串。
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string Create(HtmlHelper html)
        {
            var str = ToHtmlString();
            return str;
        }

        /// <summary>
        /// 设置内部包含的 HTML 内容。
        /// </summary>
        /// <param name="html"></param>
        public void SetInnerHtml(string html)
        {
            innerHtml = html;
        }

        private string ToHtmlString()
        {
            var sb = new StringBuilder();
            sb.Append("<" + tag);

            //构造自定义属性
            foreach (var kvp in attributes)
            {
                sb.AppendFormat(" {0}=\"{1}\"", kvp.Key, kvp.Value);
            }

            //构造 style 属性
            if (styles.Count > 0)
            {
                sb.Append(" style=\"");

                foreach (var kvp in styles)
                {
                    if (kvp.Key == "~")
                    {
                        sb.Append(kvp.Value);
                        if (sb.Length > 0 && sb[sb.Length - 1] != ';')
                        {
                            sb.Append(';');
                        }
                    }
                    else
                    {
                        sb.AppendFormat("{0}:{1};", kvp.Key, kvp.Value);
                    }
                }

                sb.Append("\"");
            }

            //构造 class 属性
            if (classes.Count > 0)
            {
                sb.Append(" class=\"");
                var assert = new AssertFlag();

                foreach (var name in classes)
                {
                    //类之间需要加空格
                    if (!assert.AssertTrue())
                    {
                        sb.Append(" ");
                    }

                    sb.Append(name);
                }

                sb.Append("\"");
            }

            if (TagClosed || !string.IsNullOrEmpty(innerHtml))
            {
                sb.Append(">");
                sb.Append(innerHtml);
                sb.Append("</" + tag + ">");
            }
            else
            {
                sb.Append(" />");
            }

            return sb.ToString();
        }
    }
}
