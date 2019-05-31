using System;
namespace AlcoCalendar.Models.Enum
{
    public enum AlcoBeverage
    {
        Beer = 0,
        Wine = 1,
        Tincture = 2,
        Vodka = 3,
        Whiskey = 4,
        Cognac = 5,
        Rum = 6,
        Absinthe = 7
    }

    public static class AlcoBeverageDegree
    {
        public static double GetDegree(this AlcoBeverage alcoBeverage)
        {
            switch(alcoBeverage)
            {
                case AlcoBeverage.Absinthe:
                    return 0.7;
                case AlcoBeverage.Beer:
                    return 0.05;
                case AlcoBeverage.Cognac:
                    return 0.4;
                case AlcoBeverage.Rum:
                    return 0.4;
                case AlcoBeverage.Tincture:
                    return 0.2;
                case AlcoBeverage.Wine:
                    return 0.15;
                case AlcoBeverage.Vodka:
                    return 0.4;
                case AlcoBeverage.Whiskey:
                    return 0.4;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
