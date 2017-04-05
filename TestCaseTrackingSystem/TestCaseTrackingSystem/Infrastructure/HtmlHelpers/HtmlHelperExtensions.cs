using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TestCaseStorage.Infrastructure.Extensions;

namespace TestCaseStorage.Infrastructure.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString TextBoxLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression, string label, string placeholder = null)
        {
            return helper.Partial("_editorRow", 
                new Tuple<string, MvcHtmlString>(
                        label,
                        helper.TextBoxFor(expression, new { @class = "form-control navbar-btn", placeholder = placeholder ?? label })));
        }

        public static MvcHtmlString TextAreaLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression, string label, string placeholder = null)
        {
            return helper.Partial("_editorRow",
                new Tuple<string, MvcHtmlString>(
                        label,
                        helper.TextAreaFor(expression, new { @class = "form-control navbar-btn", placeholder = placeholder ?? label, style = "height:100px" })));
        }

        public static MvcHtmlString DatePickerLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, DateTime>> expression, string label, string placeholder = null)
        {
            return helper.Partial("_editorRow",
                new Tuple<string, MvcHtmlString>(
                        label,
                        helper.TextBoxFor(expression, new { @class = "form-control navbar-btn date-picker", placeholder = placeholder ?? label })));
        }

        public static MvcHtmlString EnumDropDownLineFor<TModel, TEnum>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TEnum>> expression, string label, Func<TEnum, TEnum> excludeItem = null, string placeholder = null)
        {
            return helper.Partial("_editorRow",
                new Tuple<string, MvcHtmlString>(
                        label,
                        helper.DropDownListFor(expression, EnumHelpers.GetDescriptionsSelectList<TEnum>(excludeItem), "Выбрать...", new { @class = "form-control navbar-btn", placeholder = placeholder ?? label })));
        }

        public static MvcHtmlString DropDownListLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, int>> expression, IEnumerable<SelectListItem> selectList, string label, string placeholder = null)
        {
            return helper.Partial("_editorRow",
                new Tuple<string, MvcHtmlString>(
                        label,
                        helper.DropDownListFor(expression, selectList, "Выбрать...", new { @class = "form-control navbar-btn", placeholder = placeholder ?? label })));
        }
    }
}