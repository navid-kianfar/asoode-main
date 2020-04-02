using System;

namespace Asoode.Main.Core.Extensions
{
    public static class DateExtensions
    {
        public static string GetTime(this DateTime date)
        {
            return date.ToString("yyMMddhhmmssfff");
        }
    }
}