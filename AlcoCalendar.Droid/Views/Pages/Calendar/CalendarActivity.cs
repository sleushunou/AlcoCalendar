
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlcoCalendar.ViewModels.Pages.Calendar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.WhiteLabel.Droid;

namespace AlcoCalendar.Droid.Views.Pages.Calendar
{
    [Activity]
    public class CalendarActivity : ActivityBase<CalendarViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}
