using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace TestCaseStorage.Infrastructure.Extensions
{
    public static class EnumHelpers
    {
        public static IEnumerable<SelectListItem> GetDescriptionsSelectList<T>(Func<T, T> excludeItem = null)
        {
            var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            return Enum.GetValues(type).Cast<T>().Where(t => excludeItem == null || t.ToString() != excludeItem(t).ToString()).Select(t => new SelectListItem
            {
                Text = Convert.ToString(GetDescription(t)),
                Value = Convert.ToInt32(t).ToString()
            });
        }

        public static string GetDescription<T>(T enumValue)
        {
            if (enumValue == null || enumValue.ToString() == "0")
            {
                return string.Empty;
            }

            var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            var fieldInfo = type.GetField(enumValue.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
        }
    }
}