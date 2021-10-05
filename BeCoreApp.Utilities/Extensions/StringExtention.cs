using System;
using System.Collections.Generic;
using System.Text;

namespace BeCoreApp.Utilities.Extensions
{
    public static class StringExtention
    {
        public static bool EndWith(this string value, params string[] compareString)
        {
            foreach (var item in compareString)
            {
                var result = value.EndsWith(item);

                if (result)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Equals(this string value, params string[] compareString)
        {
            foreach (var item in compareString)
            {
                var result = value.Equals(item);

                if (result)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsMissing(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string MaskString(this string value)
        {
            var left = value.Substring(value.Length - 8);
            string right = value.Substring(value.Length - 6, 6);

            return string.Format("{0}.......{1}", left, right);
        }

        public static string ToTTSFormatTime(this DateTime dateTime)
        {
            return dateTime.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
