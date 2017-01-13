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

namespace Fireasy.EasyUI
{
    public static class DateTimeBoxExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 datetimebox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper DateTimeBox(this HtmlHelper htmlHelper, string exp, DateTimeBoxSettings settings = null)
        {
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilderWithCheck("INPUT", "txt", exp);
            htmlHelper.AddStyle("width", "160px")
                .EasyUI("easyui-datetimebox", options);

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 datetimebox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> DateTimeBox<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, DateTimeBoxSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;
            settings = settings ?? new DateTimeBoxSettings();
            settings.Bind(typeof(TModel), propertyName);
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilder("INPUT", "txt" + propertyName, propertyName);
            htmlHelper.AddStyle("width", "160px")
                .EasyUI("easyui-datetimebox", options);

            return htmlHelper;
        }
    }
}
