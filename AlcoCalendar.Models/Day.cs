using System;

namespace AlcoCalendar.Models
{
    public class Day
    {
        public Day(int number, Month month)
        {
            Number = number;
            Month = month;
            DayOfWeek = new DateTime(month.Year.Number, month.Number, number).DayOfWeek;
        }

        public int Number { get; }

        public DayOfWeek DayOfWeek { get; }

        public Month Month { get; }
    }
}
