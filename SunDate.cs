using System;
using System.Globalization;
using System.Linq;

namespace MyCalendar
{
    public class SunDateTime : Calendar
    {
        private static readonly PersianCalendar PersianCalendar = new PersianCalendar();
        protected override string _WeekDayName()
        {
            switch (ToDateTime().DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return "جمعه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهار شنبه";
            }
            return "error";
        }
        protected override string _MonthName()
        {
            switch (Month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
            }
            return "error";
        }
        public void FromDateTime(DateTime date)
        {
            Day = PersianCalendar.GetDayOfMonth(date);
            Month = PersianCalendar.GetMonth(date);
            Year = PersianCalendar.GetYear(date);
            Hour = PersianCalendar.GetHour(date);
            Minute = PersianCalendar.GetMinute(date);
            Second = PersianCalendar.GetSecond(date);
            Milisecond = PersianCalendar.GetMilliseconds(date);
        }
        public DateTime ToDateTime()
        {
            var dt = PersianCalendar.ToDateTime(Year, Month, Day, Hour, Minute, Second, (int)Milisecond);
            return dt;
        }
        public LuniarDate ToLuniar()
        {
            var hDate = new LuniarDate();
            hDate.FromSunDate(this);
            return hDate;
        }
        public static SunDateTime Now
        {
            get
            {
                SunDateTime sd = new SunDateTime();
                sd.FromDateTime(DateTime.Now);
                return (sd);
            }
        }
        public bool IsLeapYear
        {
            get
            {
                return PersianCalendar.IsLeapYear(Year);
            }
        }
        /// <summary>
        /// returns number of days in specefic year and months
        /// </summary>
        /// <returns></returns>
        public int DaysNum
        {
            get
            {
                bool isLeapYear = false,

                    isSecondHalfMonth = false;

                if (PersianCalendar.IsLeapYear(Year)) { isLeapYear = true; }
                if (Month > 6) { isSecondHalfMonth = true; }
                if (isLeapYear && Month == 12)
                    return 30;
                if (Month == 12)
                    return 29;
                return isSecondHalfMonth ? 30 : 31;
            }
        }
      //  public override string ToString(string format)
        //{
        //    //Minute Part
        //  //  format = format.Replace("Mm", Minute.ToString()); 
        //  //  format = format.Replace("mM", Minute.ToString()); 
        //    format = format.Replace("mm", Minute.ToString());   

        //    //Hour part
        //    //format = format.Replace("HH", Hour.ToString()); 
        //    //format = format.Replace("Hh", Hour.ToString()); 
        //   // format = format.Replace("hH", Hour.ToString()); 
        //    format = format.Replace("hh", Hour.ToString());   

        //    //Day part
        //   // format = format.Replace("DD", Day.ToString());
        //  //  format = format.Replace("Dd", Day.ToString());
        //  //  format = format.Replace("dD", Day.ToString());
        //    format = format.Replace("dd", Day.ToString());

        //    //Month part
        //    format = format.Replace("MM", Month.ToString());

        //    //Year part
        // //   format = format.Replace("YY", Year.ToString());
        // //   format = format.Replace("Yy", Year.ToString());
        // //   format = format.Replace("yY", Year.ToString());
        //    format = format.Replace("yy", Year.ToString());

        //    return format;

        //}
        public override string[] Events() => (from events in CalendarEventManagements.Events
                                              where events.Month == Month && events.Day == Day && events.CalendarType == CalendarTypes.SunDate
                                              select events.Description).ToArray();
    }
}