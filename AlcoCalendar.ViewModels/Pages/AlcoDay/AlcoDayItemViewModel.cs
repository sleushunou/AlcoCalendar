using System.Globalization;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace AlcoCalendar.ViewModels.Pages.AlcoDay
{
    public class AlcoDayItemViewModel : ObservableObject
    {
        public AlcoDayItemViewModel(AlcoItem alcoItem, ILocalizationService localizationService)
        {
            Model = alcoItem;
            Name = localizationService.GetLocalizableStirng(Model.AlcoBeverage.ToString());
        }

        public AlcoItem Model { get; }

        public string Name { get; }

        public string CountString
        {
            get => Model.Count.ToString("F", CultureInfo.CurrentCulture);
            set
            {
                if (double.TryParse(value, out var count))
                {
                    Model.Count = count;
                    RaisePropertyChanged(() => CountString);
                }
            }
        }
    }
}
