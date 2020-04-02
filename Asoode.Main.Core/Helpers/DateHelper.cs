using System;

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
    }
}