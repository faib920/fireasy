// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Linq.Expressions;
using Fireasy.Web;
using Fireasy.Web.UI;

namespace Fireasy.EasyUI
{
    public static class TextBoxExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 textbox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper TextBox(this HtmlHelper htmlHelper, string exp, TextBoxSettings settings = null)
        {
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilderWithCheck("INPUT", "txt", exp);
            htmlHelper.AddStyle("width", "160px")
                .EasyUI("easyui-textbox", options);

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 textbox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> TextBox<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TextBoxSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;
            settings = settings ?? new TextBoxSettings();
            settings.Bind(typeof(TModel), propertyName);
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilder("INPUT", "txt" + propertyName, propertyName);
            htmlHelper.AddStyle("width", "160px")
                .EasyUI("easyui-textbox", options);

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 textbox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper TextMultiBox(this HtmlHelper htmlHelper, string exp, TextBoxSettings settings = null)
        {
            settings = settings ?? new TextBoxSettings();
            settings.Multiline = true;
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilderWithCheck("TEXTAREA", "txt", exp);
            htmlHelper.Builder.TagClosed = true;
            htmlHelper.AddStyle("width", "300px")
                .AddStyle("height", "40px")
                .EasyUI("easyui-textbox", options);

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 textbox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> TextMultiBox<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TextBoxSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;
            settings = settings ?? new TextBoxSettings();
            settings.Multiline = true;
            settings.Bind(typeof(TModel), propertyName);
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilder("TEXTAREA", "txt" + propertyName, propertyName);
            htmlHelper.Builder.TagClosed = true;
            htmlHelper.AddStyle("width", "300px")
                .AddStyle("height", "40px")
                .EasyUI("easyui-textbox", options);

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 textbox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 txt 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper TextPasswordBox(this HtmlHelper htmlHelper, string exp, TextBoxSettings settings = null)
        {
            settings = settings ?? new TextBoxSettings();
            settings.Type = "password";
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilderWithCheck("INPUT", "txt", exp);
            htmlHelper.Builder.TagClosed = true;
            htmlHelper.AddAttribute("type", "password")
                .AddStyle("width", "160px")
                .EasyUI("easyui-textbox", options);

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 textbox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">ID 属性值。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> TextPasswordBox<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TextBoxSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;
            settings = settings ?? new TextBoxSettings();
            settings.Type = "password";
            settings.Bind(typeof(TModel), propertyName);
            var options = SettingsSerializer.Serialize(settings);

            htmlHelper.ResetBuilder("INPUT", "txt" + propertyName, propertyName);
            htmlHelper.Builder.TagClosed = true;
            htmlHelper.AddAttribute("type", "password")
                .AddStyle("width", "160px")
                .EasyUI("easyui-textbox", options);

            return htmlHelper;
        }
    }
}
