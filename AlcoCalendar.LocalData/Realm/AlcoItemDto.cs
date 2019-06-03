using System;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;
using Realms;

namespace AlcoCalendar.LocalData.Realm
{
    internal class AlcoItemDto : RealmObject
    {
        public AlcoItemDto() { }

        public AlcoItemDto(AlcoItem alcoItem)
        {
            AlcoBeverage = (int)alcoItem.AlcoBeverage;
            Count = alcoItem.Count;
        }

        public int AlcoBeverage { get; set; }

        public double Count { get; set; }
    }
}
