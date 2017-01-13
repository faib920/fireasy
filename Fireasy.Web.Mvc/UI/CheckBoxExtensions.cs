// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Web.UI;
using System;
using System.Linq.Expressions;

namespace Fireasy.Web.Mvc.UI
{
    public static class CheckBoxExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 checkbox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">ID 属性值。</param>
        /// <param name="checked">默认是否选中。</param>
        /// <returns></returns>
        public static HtmlHelper CheckBox(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, bool @checked = false)
        {
            return new HtmlHelper().CheckBox(exp, @checked);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 checkbox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="checked">默认是否选中。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> CheckBox<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool @checked = false)
        {
            return new HtmlHelper<TModel>().CheckBox(expression, @checked);
        }
    }
}
