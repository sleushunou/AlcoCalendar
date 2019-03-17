// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AlcoCalendar.iOS.ViewControllers.Calendar
{
    [Register ("CalendarViewController")]
    partial class CalendarViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView CalendarCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MonthAndYearLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PrevButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CalendarCollectionView != null) {
                CalendarCollectionView.Dispose ();
                CalendarCollectionView = null;
            }

            if (MonthAndYearLabel != null) {
                MonthAndYearLabel.Dispose ();
                MonthAndYearLabel = null;
            }

            if (NextButton != null) {
                NextButton.Dispose ();
                NextButton = null;
            }

            if (PrevButton != null) {
                PrevButton.Dispose ();
                PrevButton = null;
            }
        }
    }
}