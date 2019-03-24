using AlcoCalendar.ViewModels.Pages.Start;
using Foundation;
using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.WhiteLabel.iOS;
using Softeq.XToolkit.WhiteLabel.Navigation;
using System;
using UIKit;

namespace AlcoCalendar.iOS.ViewControllers.Calendar
{
    public partial class StartPageViewController : ViewControllerBase<StartPageViewModel>
    {
        private UINavigationController _t;

        public StartPageViewController (IntPtr handle) : base (handle)
        {
            SetExistingViewModel(Dependencies.IocContainer.Resolve<StartPageViewModel>());

            Dependencies.IocContainer.Resolve<IPageNavigationService>()
                .Initialize(NavigationController);

            _t = NavigationController;
        }
    }
}