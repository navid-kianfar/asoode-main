using System;
using System.Globalization;
using System.Threading;

namespace Asoode.Main.Core.Helpers
{
    public static class DateHelper
    {
        public static DateTime FromUnixTime(long unixTime)
        {
            var sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return sTime.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime datetime)
        {
            var sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long) (datetime - sTime).TotalSeconds;
        }
        
        public static string PubDate(DateTime pubDate)
        {
            var value = pubDate.ToString("ddd',' d MMM yyyy HH':'mm':'ss") +
                        " " +
                        pubDate.ToString("zzzz").Replace(":", "");
            return value;
        }

        public static string Format(DateTime date, string format = "yyyy/MM/dd", string culture = null)
        {
            if (string.IsNullOrEmpty(culture)) 
                culture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            return date.ToString(format, new CultureInfo(culture));
        }
    }
}