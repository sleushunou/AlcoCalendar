using Foundation;
using System;
using UIKit;

namespace AlcoCalendar.iOS
{
    public partial class CalendarHeaderView : UICollectionReusableView
    {
        public CalendarHeaderView (IntPtr handle) : base (handle)
        {
        }

        internal void SetData(string[] dayOfWeek)
        {
            if(dayOfWeek == null || dayOfWeek.Length != 7)
            {
                throw new Exception("array must contain 7 elements");
            }

            FirstLabel.Text = dayOfWeek[0];
            SecondLabel.Text = dayOfWeek[1];
            ThirdLabel.Text = dayOfWeek[2];
            FourthLabel.Text = dayOfWeek[3];
            FifthLabel.Text = dayOfWeek[4];
            SixthLabel.Text = dayOfWeek[5];
            SeventhLabel.Text = dayOfWeek[6];
        }
    }
}