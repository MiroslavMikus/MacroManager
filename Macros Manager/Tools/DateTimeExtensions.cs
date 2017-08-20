using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macros_Manager.Tools
{
    public static class DateTimeExtensions
    {
        public static DateTime CreateDateFromTime(this DateTime a_time, int a_year, int a_month, int a_day)
        {
            return new DateTime(a_year, a_month, a_day, a_time.Hour, a_time.Minute, 0);
        }

        public static DateTime CreateDateFromDate(this DateTime a_date, int a_hour, int a_minute)
        {
            return new DateTime(a_date.Year, a_date.Month, a_date.Day, a_hour, a_minute, 0);
        }
    }
}
