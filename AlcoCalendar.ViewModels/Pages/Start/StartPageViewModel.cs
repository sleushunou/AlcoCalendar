using System;
using AlcoCalendar.ViewModels.Pages.Calendar;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.ViewModels.Pages.Start
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;

        public StartPageViewModel(IPageNavigationService pageNavigationService)
        {
            _pageNavigationService = pageNavigationService;
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            _pageNavigationService.NavigateToViewModel<CalendarViewModel>(true);
        }
    }
}
