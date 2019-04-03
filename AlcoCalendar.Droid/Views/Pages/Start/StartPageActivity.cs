
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlcoCalendar.ViewModels.Pages.Start;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.Droid.Views
{
    [Activity]
    public class StartPageActivity : ActivityBase<StartPageViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}
