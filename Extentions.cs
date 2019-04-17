using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
   public static class Extentions
    {
        public static SunDateTime ToSunDate(this DateTime dateTime)
        {
            SunDateTime sunDateTime = new SunDateTime();
            sunDateTime.FromDateTime(dateTime);
            return sunDateTime;
        }
    }
}
