using Fireasy.Web.UI;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Linq.Expressions;

namespace Fireasy.EasyUI.Mvc
{
    public static class ValidateBoxExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper ValidateBox(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, ValidateBoxSettings settings = null)
        {
            return new HtmlHelper().ValidateBox(exp, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> ValidateBox<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ValidateBoxSettings settings = null)
        {
            return new HtmlHelper<TModel>().ValidateBox(expression, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper ValidateMultiBox(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, ValidateBoxSettings settings = null)
        {
            return new HtmlHelper().ValidateMultiBox(exp, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> ValidateMultiBox<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ValidateBoxSettings settings = null)
        {
            return new HtmlHelper<TModel>().ValidateMultiBox(expression, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper ValidatePasswordBox(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, ValidateBoxSettings settings = null)
        {
            return new HtmlHelper().ValidatePasswordBox(exp, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">ID 属性值。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> ValidatePasswordBox<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TextBoxSettings settings = null)
        {
            return new HtmlHelper<TModel>().ValidatePasswordBox(expression, settings);
        }
    }
}
