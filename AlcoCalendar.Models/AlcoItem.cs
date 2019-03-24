using System;
using AlcoCalendar.Models.Enum;

namespace AlcoCalendar.Models
{
    public class AlcoItem
    {
        public AlcoItem(AlcoBeverage alcoBeverage)
        {
            AlcoBeverage = alcoBeverage;
        }

        public AlcoBeverage AlcoBeverage { get; }

        public double Count { get; set; }
    }
}
