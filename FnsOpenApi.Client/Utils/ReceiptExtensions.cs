using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace FnsOpenApi.Client.Utils
{
    public static class ReceiptExtensions
    {
        public static string ToReceiptDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:00");
        }

        public static int ToReceiptAmount(this double amount)
        {
            return Convert.ToInt32(amount * 100);
        }

        public static T TrimAllStringProperties<T>(this T obj)
        {
            var properties = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.PropertyType == typeof(string))
                .ToList();

            foreach (var property in properties)
            {
                var strValue = property.GetValue(obj)?.ToString();
                if (string.IsNullOrEmpty(strValue)) continue;
                strValue = strValue.Trim();
                property.SetValue(obj, strValue);
            }

            return obj;
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}