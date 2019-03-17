using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlcoCalendar.Models
{
    public class Year
    {
        public Year(int number)
        {
            Number = number;
            Months = new ReadOnlyCollection<Month>(new List<Month>(Enumerable.Range(1, 12)
                .Select(numberOfMonth => new Month(numberOfMonth, this))));
        }

        public int Number { get; }

        public IReadOnlyList<Month> Months { get; }
    }
}
