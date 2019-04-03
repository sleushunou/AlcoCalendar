
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.WhiteLabel.Droid.Dialogs;

namespace AlcoCalendar.Droid.Views.Pages.AlcoDay
{
    [Activity]
    public class AlcoDayDialogFragment : DialogFragmentBase<AlcoDayViewModel>
    {
        protected override int ThemeId => Resource.Style.Theme_AppCompat_Light_NoActionBar;
    }
}
