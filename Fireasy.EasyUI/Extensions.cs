// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Linq.Expressions;
using Fireasy.Web.UI;

namespace Fireasy.EasyUI
{
    /// <summary>
    /// 为 <see cref="HtmlHelper"/> 提供 EasyUI 的扩展支持。
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 对 <see cref="HtmlHelper"/> 对象使用 EasyUI 类及选项。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="className">类的名称。</param>
        /// <param name="options">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper EasyUI(this HtmlHelper htmlHelper, string className, string options)
        {
            return htmlHelper.AddClass(className)
                .AddAttribute("data-options", options);
        }

        /// <summary>
        /// 打上一个标记，form 的 clear 方法将忽略此域。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static HtmlHelper MarkNoClear(this HtmlHelper htmlHelper)
        {
            return htmlHelper.AddAttribute("noclear", "true");
        }

        /// <summary>
        /// 打上一个标记，combobox、combotree 的值暂存到属性 _value 中，设值操作迟延到事件 onLoadSuccess 里进行。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static HtmlHelper MarkDelayedSet(this HtmlHelper htmlHelper)
        {
            return htmlHelper.AddAttribute("delay", "true");
        }
    }
}
