using System;
using System.Globalization;
using System.Linq;

namespace MyCalendar
{
    public class LuniarDate : Calendar
    {
        static readonly HijriCalendar HCal = new HijriCalendar();
        public static LuniarDate Now()
        {
            LuniarDate hd = new LuniarDate();
            DateTime miladi = DateTime.Now;
            hd.Day = HCal.GetDayOfMonth(miladi);
            hd.Month = HCal.GetMonth(miladi);
            hd.Year = HCal.GetYear(miladi);
            return hd;
        }
        public void FromSunDate(SunDateTime sDate)
        {
            DateTime miladi = sDate.ToDateTime();
            Day = HCal.GetDayOfMonth(miladi);
            Month = HCal.GetMonth(miladi);
            Year = HCal.GetYear(miladi);
        }
        protected override string _MonthName()
        {
            switch (Month)
            {
                case 1:
                    return "محرم";
                case 2:
                    return "صفر";
                case 3:
                    return "ربیع الاول";
                case 4:
                    return "ربیع الثانی";
                case 5:
                    return "جمادی الاول";
                case 6:
                    return "جمادی اثانی";
                case 7:
                    return "رجب";
                case 8:
                    return "شعبان";
                case 9:
                    return "رمضان";
                case 10:
                    return "شوال";
                case 11:
                    return "ذی القعده";
                case 12:
                    return "ذی الحجه";
                default:
                    return "";
            }
        }
        public override string[] Events() => CalendarEventManagements.Events.Where(x => x.Month == Month && x.Day == Day).Select(x => x.Description).ToArray();

    }
}