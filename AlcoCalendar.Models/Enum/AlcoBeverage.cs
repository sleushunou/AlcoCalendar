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
        public static int GetDegree(this AlcoBeverage alcoBeverage)
        {
            switch(alcoBeverage)
            {
                case AlcoBeverage.Absinthe:
                    return 70;
                case AlcoBeverage.Beer:
                    return 5;
                case AlcoBeverage.Cognac:
                    return 40;
                case AlcoBeverage.Rum:
                    return 40;
                case AlcoBeverage.Tincture:
                    return 20;
                case AlcoBeverage.Wine:
                    return 15;
                case AlcoBeverage.Vodka:
                    return 40;
                case AlcoBeverage.Whiskey:
                    return 40;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
