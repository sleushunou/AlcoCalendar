using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace AlcoCalendar.Models
{
    public class Month
    {
        public Month(int number, Year year)
        {
            Number = number;
            Year = year;
            Days = new ReadOnlyCollection<Day>(new List<Day>(Enumerable.Range(1, DateTime.DaysInMonth(Year.Number, Number))
                .Select(numberOfDay => new Day(numberOfDay, this))));
        }

        public int Number { get; }

        public IReadOnlyList<Day> Days { get; }

        public Year Year { get; }
    }
}
