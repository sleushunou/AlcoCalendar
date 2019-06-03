using System;
using Android.Support.Design.Widget;

namespace AlcoCalendar.Droid
{
    public class AntiLinker
    {
        private TextInputEditText textView;
        public AntiLinker()
        {
            textView.TextChanged += (sender, e) => { };
        }
    }
}
