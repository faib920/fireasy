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
using Fireasy.Web;
using Fireasy.Web.UI;

namespace Fireasy.EasyUI.Mvc
{
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 combobox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 cbo 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper ComboBox(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, ComboBoxSettings settings = null)
        {
            return new HtmlHelper().ComboBox(exp, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 combobox 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 cbo 作为前缀的 ID 名称。</param>
        /// <param name="enumType">枚举类型。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper ComboBox(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, Type enumType, ComboBoxSettings settings = null)
        {
            return new HtmlHelper().ComboBox(exp, enumType, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> ComboBox<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ComboBoxSettings settings = null)
        {
            return new HtmlHelper<TModel>().ComboBox(expression, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 validatebox 元素。使用一个枚举类型输出 Key-Value 数组，Value 是使用 <see cref="EnumDescriptionAttribute"/> 标注的。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="enumType">要绑定的枚举类型。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> ComboBox<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type enumType, ComboBoxSettings settings = null)
        {
            return new HtmlHelper<TModel>().ComboBox(expression, enumType, settings);
        }

        private static string BuildEnumOptions(Type enumType)
        {
            var sb = new StringBuilder();
            foreach (var kvp in enumType.GetEnumList())
            {
                sb.AppendFormat("<option value=\"{0}\">{1}</option>", kvp.Key, kvp.Value);
            }

            return sb.ToString();
        }
    }
}
