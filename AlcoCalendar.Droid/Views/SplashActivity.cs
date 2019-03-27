
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AlcoCalendar.Droid.Views
{
    [Activity(MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = new Intent(this, typeof(StartPageActivity));

            if (Intent?.Extras != null)
            {
                intent.PutExtras(Intent.Extras);
            }

            StartActivity(intent);
            Finish();
        }
    }
}
