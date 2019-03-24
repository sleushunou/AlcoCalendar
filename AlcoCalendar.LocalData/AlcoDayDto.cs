using System;
using System.Collections.Generic;
using System.Linq;
using AlcoCalendar.Models;

namespace AlcoCalendar.LocalData
{
    public class AlcoDayDto
    {
        public AlcoDayDto() { }

        public AlcoDayDto(IList<AlcoItem> alcoItems, Day day)
        {
            Key = GetKey(day);
            AlcoItems = alcoItems.Select(x => new AlcoItemDto(x)).ToList();
        }

        public string Key { get; set; }

        public IList<AlcoItemDto> AlcoItems { get; set; }

        public static string GetKey(Day day)
        {
            return $"{nameof(AlcoDayDto)}.{day.Month.Year.Number}.{day.Month.Number}.{day.Number}";
        }
    }
}
