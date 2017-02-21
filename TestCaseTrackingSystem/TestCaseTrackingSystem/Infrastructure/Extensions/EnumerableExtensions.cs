using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TestCaseStorage.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T, TTextProperty, TValueProperty>(this IEnumerable<T> instance, Func<T, TTextProperty> text, Func<T, TValueProperty> value, Func<T, bool> selectedItem = null)
        {
            return instance.Select(t => new SelectListItem
            {
                Text = Convert.ToString(text(t)),
                Value = Convert.ToString(value(t)),
                Selected = selectedItem?.Invoke(t) ?? false
            });
        }
    }
}