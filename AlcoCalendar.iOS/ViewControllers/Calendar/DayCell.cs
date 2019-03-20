using AlcoCalendar.ViewModels.Pages.Calendar;
using Foundation;
using System;
using UIKit;

namespace AlcoCalendar.iOS.ViewControllers.Calendar
{
    public partial class DayCell : UICollectionViewCell
    {
        public DayCell (IntPtr handle) : base (handle)
        {
        }

        internal void BindCell(DayViewModel item)
        {
            NumberLabel.Text = item.DayNumber;
            NumberLabel.TextColor = item.IsInSelectedMonth ?
                UIColor.Black : UIColor.Gray;
        }
    }
}