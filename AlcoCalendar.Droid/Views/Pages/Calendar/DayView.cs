
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AlcoCalendar.Droid.Views.Pages.Calendar
{
    [Register("com.alcocalendar.droid.views.DayView")]
    public class DayView : LinearLayout
    {
        public DayView(Context context) :
            base(context)
        {
            Initialize();
        }

        public DayView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public DayView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, widthMeasureSpec);
        }

        void Initialize()
        {
        }
    }
}
