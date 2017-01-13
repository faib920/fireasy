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

namespace Fireasy.EasyUI.Mvc
{
    public static class NumberSpinnerExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 numberspinner 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper NumberSpinner(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, NumberSpinnerSettings settings = null)
        {
            return new HtmlHelper().NumberSpinner(exp, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 numberspinner 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> NumberSpinner<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, NumberSpinnerSettings settings = null)
        {
            return new HtmlHelper<TModel>().NumberSpinner(expression, settings);
        }
    }
}
