using System.Globalization;
using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace AlcoCalendar.ViewModels.Pages.AlcoDay
{
    public class AlcoDayItemViewModel : ObservableObject
    {
        private string _name;
        private double _count;

        public AlcoDayItemViewModel(AlcoBeverage alcoBeverage, ILocalizationService localizationService)
        {
            Model = alcoBeverage;
            Name = localizationService.GetLocalizableStirng(Model.ToString());
        }

        public AlcoBeverage Model { get; }

        public string Name
        {
            get => _name;
            set { Set(() => Name, ref _name, value); }
        }

        public string CountString
        {
            get => _count.ToString("F", CultureInfo.CurrentCulture);
            set
            {
                double.TryParse(value, out _count);
                RaisePropertyChanged(() => CountString);
            }
        }
    }
}
