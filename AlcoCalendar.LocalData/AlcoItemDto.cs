using System;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;

namespace AlcoCalendar.LocalData
{
    public class AlcoItemDto
    {
        public AlcoItemDto() { }

        public AlcoItemDto(AlcoItem alcoItem)
        {
            AlcoBeverage = alcoItem.AlcoBeverage;
            Count = alcoItem.Count;
        }

        public AlcoBeverage AlcoBeverage { get; set; }

        public double Count { get; set; }
    }
}
