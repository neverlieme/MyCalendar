using System;
using System.Linq;


namespace MyCalendar
{

    public class Calendar
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public double Milisecond { get; set; }
        public string MonthName => _MonthName();
        public string WeekDayName => _WeekDayName();
        protected virtual string _WeekDayName()
        {
            return "";
        }
        protected virtual string _MonthName()
        {
            return "";
        }

        public override string ToString()
        {
            return Year.ToString("0000") + "/" + Month.ToString("00") + "/" + Day.ToString("00");
        }
        /// <summary>
        /// Initializes current object with a string like "1395/11/6"
        /// </summary>
        /// <param name="date"></param>
        public void FromString(string date)
        {
            string[] str = date.Split('/');
            Day = Convert.ToInt32(str[2]);
            Month = Convert.ToInt32(str[1]);
            Year = Convert.ToInt32(str[0]);
        }
        public void FromString(string date, string format)
        {
            int secondIndex = format.IndexOf("ss");
            int minuteIndex = format.IndexOf("MM");
            int hourIndex = format.IndexOf("hh");
            int dayIndex = format.IndexOf("dd");
            int monthIndex = format.IndexOf("mm");
            int yearIndex = format.IndexOf("yyyy");
            if (secondIndex > 0)
                Second = int.Parse(date.Substring(secondIndex, 2));
            Minute = int.Parse(date.Substring(minuteIndex, 2));
            Hour = int.Parse(date.Substring(hourIndex, 2));
            Day = int.Parse(date.Substring(dayIndex, 2));
            Month = int.Parse(date.Substring(monthIndex, 2));
            Year = int.Parse(date.Substring(yearIndex, 4));
        }
        public virtual string ToString(string format)
        {
            format = format.Replace("ss", Second.ToString("00"));
            format = format.Replace("MM", Minute.ToString("00"));
            format = format.Replace("hh", Hour.ToString("00"));
            format = format.Replace("dd", Day.ToString("00"));
            format = format.Replace("mm", Month.ToString("00"));
            format = format.Replace("yyyy", Year.ToString("0000"));
           
            format = format.Replace("w", WeekDayName);
            format = format.Replace("m^", MonthName);
            return format;
        }
        public virtual string[] Events()
        {
            return new string[] { };
        }

    }


    public enum DateOutType
    {
        SimpleString
    }
}