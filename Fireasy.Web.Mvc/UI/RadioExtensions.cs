using Fireasy.Web.UI;
using System;
using System.Linq.Expressions;

namespace Fireasy.Web.Mvc.UI
{
    public static class RadioExtensions
    {
        public static HtmlHelper RadioGroup(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, Type enumType, RadioGroupSettings settings = null)
        {
            return new HtmlHelper().RadioGroup(exp, enumType, settings);
        }

        public static HtmlHelper RadioGroup(this System.Web.Mvc.HtmlHelper htmlHelper, string exp, RadioGroupSettings settings = null)
        {
            return new HtmlHelper().RadioGroup(exp, settings);
        }

        public static HtmlHelper<TModel> RadioGroup<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type enumType, RadioGroupSettings settings = null)
        {
            return new HtmlHelper<TModel>().RadioGroup(expression, enumType, settings);
        }

        public static HtmlHelper<TModel> RadioGroup<TModel, TProperty>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, RadioGroupSettings settings = null)
        {
            return new HtmlHelper<TModel>().RadioGroup(expression, settings);
        }
    }
}
