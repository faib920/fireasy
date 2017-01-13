// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using System;
using System.Linq.Expressions;
using System.Text;

namespace Fireasy.Web.UI
{
    public static class RadioExtensions
    {
        public static HtmlHelper RadioGroup(this HtmlHelper htmlHelper, string exp, RadioGroupSettings settings = null)
        {
            htmlHelper.ResetBuilderWithCheck("DIV", "rgp", exp);
            htmlHelper.AddClass("radio-group");
            htmlHelper.AddStyle("width", "160px");
            htmlHelper.Builder.SetInnerHtml(BuildRadioOptions(exp, settings));

            return htmlHelper;
        }

        public static HtmlHelper RadioGroup(this HtmlHelper htmlHelper, string exp, Type enumType, RadioGroupSettings settings = null)
        {
            htmlHelper.ResetBuilderWithCheck("DIV", "rgp", exp);
            htmlHelper.AddClass("radio-group");
            htmlHelper.AddStyle("width", "160px");
            htmlHelper.Builder.SetInnerHtml(BuildRadioOptions(exp, enumType, settings));

            return htmlHelper;
        }

        public static HtmlHelper<TModel> RadioGroup<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, RadioGroupSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;

            htmlHelper.ResetBuilder("DIV", "rgp" + propertyName, propertyName);
            htmlHelper.AddClass("radio-group");
            htmlHelper.AddStyle("width", "160px");
            htmlHelper.Builder.SetInnerHtml(BuildRadioOptions(propertyName, settings));

            return htmlHelper;
        }

        public static HtmlHelper<TModel> RadioGroup<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type enumType, RadioGroupSettings settings = null)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;

            htmlHelper.ResetBuilder("DIV", "rgp" + propertyName, propertyName);
            htmlHelper.AddClass("radio-group");
            htmlHelper.AddStyle("width", "160px");
            htmlHelper.Builder.SetInnerHtml(BuildRadioOptions(propertyName, enumType, settings));

            return htmlHelper;
        }

        private static string BuildRadioOptions(string name, RadioGroupSettings settings)
        {
            if (settings == null || settings.Items == null)
            {
                return string.Empty;
            }

            var width = settings.ItemWidth == null ? string.Empty : "width: " + settings.ItemWidth + "px;";
            var sb = new StringBuilder();
            foreach (var kvp in settings.Items)
            {
                var chk = settings.Value != null && settings.Value.ToString() == kvp.Key
                    ? " checked=\"checked\"" : string.Empty;

                sb.AppendFormat("<div style=\"float:left;{3}\"><input type=\"radio\" id=\"{0}_{1}\" name=\"{0}\" value=\"{1}\"{4} /><label for=\"{0}_{1}\">{2}</label></div>",
                    name, kvp.Key, kvp.Value, width, chk);
            }

            return sb.ToString();
        }

        private static string BuildRadioOptions(string name, Type enumType, RadioGroupSettings settings)
        {
            var width = settings == null || settings.ItemWidth == null ? string.Empty : "width: " + settings.ItemWidth + "px;";
            var sb = new StringBuilder();
            foreach (var kvp in enumType.GetEnumList())
            {
                var chk = settings != null && settings.Value != null && settings.Value.To<int>() == kvp.Key 
                    ? " checked=\"checked\"" : string.Empty;

                sb.AppendFormat("<div style=\"float:left;{4}\"><input type=\"radio\" id=\"{3}_{0}_{1}\" name=\"{3}\" value=\"{1}\"{5} /><label for=\"{3}_{0}_{1}\">{2}</label></div>",
                    enumType.Name, kvp.Key, kvp.Value, name, width, chk);
            }

            return sb.ToString();
        }
    }
}
