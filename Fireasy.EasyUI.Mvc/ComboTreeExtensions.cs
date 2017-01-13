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

namespace Fireasy.EasyUI.Mvc
{
    public static class ComboTreeExtensions
    {
        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 combotree 元素。
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="exp">属性名或使用 cbo 作为前缀的 ID 名称。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper ComboTree(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, ComboTreeSettings settings = null)
        {
            return new HtmlHelper().ComboTree(exp, settings);
        }

        /// <summary>
        /// 为 <see cref="HtmlHelper"/> 对象扩展 combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">数据模型类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性的类型。</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">指定绑定属性的表达式。</param>
        /// <param name="settings">参数选项。</param>
        /// <returns></returns>
        public static HtmlHelper<TModel> ComboTree<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ComboTreeSettings settings = null)
        {
            return new HtmlHelper<TModel>().ComboTree(expression, settings);
        }
    }
}
