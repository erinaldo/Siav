using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public static  class DateCalc
    {
        public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek day)
        {
            int diff = day - dt.DayOfWeek;

            //se o dia ja passou, calcular o da proxima semana
            if (diff < 0)
                diff += 7;

            return dt.AddDays(diff).Date;
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
                diff += 7;

            return dt.AddDays(-1 * diff).Date;
        }

        
    }
}
