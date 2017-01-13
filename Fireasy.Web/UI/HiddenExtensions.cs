using System;
using System.Linq.Expressions;

namespace Fireasy.Web.UI
{
    public static class HiddenExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 hidden 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static HtmlHelper Hidden(this HtmlHelper htmlHelper, string exp)
        {
            htmlHelper.ResetBuilderWithCheck("INPUT", "txt", exp);
            htmlHelper.AddAttribute("type", "hidden");

            return htmlHelper;
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 hidden 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> Hidden<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = new ModelPropertyBinder(expression);
            var propertyName = metadata.PropertyName;

            htmlHelper.ResetBuilder("INPUT", "txt" + propertyName, propertyName);
            htmlHelper.AddAttribute("type", "hidden");

            return htmlHelper;
        }
    }
}
