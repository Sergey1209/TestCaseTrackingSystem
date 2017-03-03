using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TestCaseStorage.Infrastructure.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString TextBoxLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression, string label, string placeholder = null)
        {
            var html = EditRow(
                LabelCell(helper, label),
                TextEditorCell(helper, expression, label, placeholder)
            );

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString DatePickerLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, DateTime>> expression, string label, string placeholder = null)
        {
            var html = EditRow(
                LabelCell(helper, label),
                DateEditorCell(helper, expression, label, placeholder)
                );

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString EnumDropDownLineFor<TModel, TEnum>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TEnum>> expression, string label, string placeholder = null)
        {
            var html = EditRow(
                LabelCell(helper, label),
                EnumDropdownEditorCell(helper, expression, label, placeholder)
                );

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString DropDownListLineFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, int>> expression, IEnumerable<SelectListItem> selectList, string label, string placeholder = null)
        {
            var html = EditRow(
                LabelCell(helper, label),
                DropdownListEditorCell(helper, expression, selectList, label, placeholder)
                );

            return MvcHtmlString.Create(html);
        }

        private static string TextEditorCell<TModel>(HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression, string label, string placeholder)
        {
            return EditorCell(helper.TextBoxFor(expression, new { @class = "form-control navbar-btn", placeholder = placeholder ?? label }).ToString());
        }

        private static string DateEditorCell<TModel>(HtmlHelper<TModel> helper, Expression<Func<TModel, DateTime>> expression, string label, string placeholder)
        {
            return EditorCell(helper.TextBoxFor(expression, new { @class = "form-control navbar-btn date-picker", placeholder = placeholder ?? label }).ToString());
        }

        private static string EnumDropdownEditorCell<TModel, TEnum>(HtmlHelper<TModel> helper, Expression<Func<TModel, TEnum>> expression, string label, string placeholder)
        {
            return EditorCell(helper.EnumDropDownListFor(expression, "Select...", new { @class = "form-control navbar-btn", placeholder = placeholder ?? label }).ToString());
        }

        private static string DropdownListEditorCell<TModel>(HtmlHelper<TModel> helper, Expression<Func<TModel, int>> expression, IEnumerable<SelectListItem> selectList, string label, string placeholder)
        {
            return EditorCell(helper.DropDownListFor(expression, selectList, "Select...", new { @class = "form-control navbar-btn", placeholder = placeholder ?? label }).ToString());
        }

        private static string EditorCell(string cellContent)
        {
            return
                "<div class=\"col-lg-3 input-group-lg\">" + Environment.NewLine +
                cellContent + Environment.NewLine +
                "</div>";
        }

        private static string EditRow(string labelCell, string editorCell)
        {
            return
                "<div class=\"row\">" + Environment.NewLine +
                labelCell + Environment.NewLine +
                editorCell + Environment.NewLine +
               "</div>";
        }

        private static string LabelCell(HtmlHelper htmlHelper, string label)
        {
            return
                "<div class=\"col-lg-2 col-lg-offset-3 text-right\">" + Environment.NewLine +
                htmlHelper.Label(label, new {@class = "edit-line-label"}) + Environment.NewLine +
                "</div>";
        }
    }
}