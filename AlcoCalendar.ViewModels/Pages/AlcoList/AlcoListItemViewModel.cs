using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace AlcoCalendar.ViewModels.Pages.AlcoList
{
    public class AlcoListItemViewModel : ObservableObject
    {
        public AlcoListItemViewModel(AlcoBeverage alcoBeverage, ILocalizationService localizationService)
        {
            Model = alcoBeverage;
            Name = localizationService.GetLocalizableStirng(Model.ToString());
            Percent = Model.GetDegree().ToString();
        }

        public AlcoBeverage Model { get; }

        public string Name { get; }

        public string Percent { get; }

        public bool IsSelected { get; set; }
    }
}
