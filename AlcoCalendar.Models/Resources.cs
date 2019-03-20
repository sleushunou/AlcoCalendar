using System;
using AlcoCalendar.Models.Interfaces;

namespace AlcoCalendar.Models
{
    public class Resources
    {
        public static Resources Current { get; set; }

        private readonly ILocalizationService _localizationService;

        public Resources(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public string Beer => _localizationService.GetLocalizableStirng(nameof(Beer));

        public string Wine => _localizationService.GetLocalizableStirng(nameof(Wine));

        public string Tincture => _localizationService.GetLocalizableStirng(nameof(Tincture));

        public string Vodka => _localizationService.GetLocalizableStirng(nameof(Vodka));

        public string Whiskey => _localizationService.GetLocalizableStirng(nameof(Whiskey));

        public string Cognac => _localizationService.GetLocalizableStirng(nameof(Cognac));

        public string Rum => _localizationService.GetLocalizableStirng(nameof(Rum));

        public string Absinthe => _localizationService.GetLocalizableStirng(nameof(Absinthe));

        public string AddAlcohol => _localizationService.GetLocalizableStirng(nameof(AddAlcohol));
    }
}
