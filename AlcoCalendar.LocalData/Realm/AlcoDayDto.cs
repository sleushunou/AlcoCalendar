using System;
using System.Collections.Generic;
using System.Linq;
using AlcoCalendar.Models;
using Realms;

namespace AlcoCalendar.LocalData.Realm
{
    internal class AlcoDayDto : RealmObject
    {
        public AlcoDayDto() { }

        public AlcoDayDto(IList<AlcoItem> alcoItems, Day day)
        {
            Key = GetKey(day);
            AlcoItems = alcoItems.Select(x => new AlcoItemDto(x)).ToList();
        }

        [PrimaryKey]
        public string Key { get; set; }

        public IList<AlcoItemDto> AlcoItems { get; }

        public static string GetKey(Day day)
        {
            return $"{nameof(AlcoDayDto)}.{day.Month.Year.Number}.{day.Month.Number}.{day.Number}";
        }
    }
}
