using System.Collections.Generic;


namespace MyCalendar
{
    public static class CalendarEventManagements
    {
        private static List<CalendarEvent> _events;

        public static List<CalendarEvent> Events
        {
            get
            {
                if (_events != null) return _events;
                Init();
                return _events;
            }

        }
        public static void AddEvent(string description,int day,int month,bool isHoliday,CalendarTypes calendarType)
        {
            _events.Add(new MyCalendar.CalendarEvent { Day = day, Description = description, Month = month, IsHoliday = isHoliday, CalendarType = calendarType });
        }
        private static void Init()
        {
            _events = new List<CalendarEvent>
            {
                //sundate events
                new CalendarEvent { Day = 3, Month = 4, Description = "Hello",CalendarType = CalendarTypes.SunDate},
                //luniar events
               new CalendarEvent { Day = 28,Month = 2,Description = "شهادت حضرت رسول"}
            };
        }
    }
}