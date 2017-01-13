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

namespace Fireasy.Web.UI
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
        public static HtmlHelper CheckBox(this HtmlHelper htmlHelper, string exp, bool @checked = false)
        {
            htmlHelper.ResetBuilder("INPYT", "chk", exp);
            htmlHelper.AddAttribute("type", "checkbox");

            if (@checked)
            {
                htmlHelper.AddAttribute("checked", "checked");
            }

            return htmlHelper;
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
        public static HtmlHelper<TModel> CheckBox<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool @checked = false)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;

            htmlHelper.ResetBuilder("INPUT", "chk" + propertyName, propertyName);
            htmlHelper.AddAttribute("type", "checkbox");

            if (@checked)
            {
                htmlHelper.AddAttribute("checked", "checked");
            }

            return htmlHelper;
        }
    }
}
