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
    public static class NumberSpinnerExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 numberspinner 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper NumberSpinner(this HtmlHelper htmlHelper, string exp, NumberSpinnerSettings settings = null)
        {
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilderWithCheck("INPUT", "txt", exp);
            htmlHelper.EasyUI("easyui-numberspinner", options);

            return htmlHelper;
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
        public static HtmlHelper<TModel> NumberSpinner<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, NumberSpinnerSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;
            settings = settings ?? new NumberSpinnerSettings();
            settings.Bind(typeof(TModel), propertyName);
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilder("INPUT", "txt" + propertyName, propertyName);
            htmlHelper.AddStyle("width", "160px")
                .EasyUI("easyui-numberspinner", options);

            return htmlHelper;
        }
    }
}
