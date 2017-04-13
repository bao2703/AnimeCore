using System;

namespace AnimeCore.Common
{
    public static class DateTimeExtension
    {
        public static string Format(this DateTime dateTime)
        {
            return dateTime.ToString(Constant.DateFormat);
        }
    }
}