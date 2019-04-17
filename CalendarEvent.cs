namespace MyCalendar
{
    public class CalendarEvent
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public string Description { get; set; }
        public bool IsHoliday { get; set; }
        public CalendarTypes CalendarType { get; set; }
    }

    public enum CalendarTypes
    {
        SunDate,
        LuniarDate
    }
}