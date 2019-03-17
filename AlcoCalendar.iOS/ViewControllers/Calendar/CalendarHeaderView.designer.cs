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
    [Register ("CalendarHeaderView")]
    partial class CalendarHeaderView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FifthLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FourthLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SecondLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SeventhLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SixthLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ThirdLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FifthLabel != null) {
                FifthLabel.Dispose ();
                FifthLabel = null;
            }

            if (FirstLabel != null) {
                FirstLabel.Dispose ();
                FirstLabel = null;
            }

            if (FourthLabel != null) {
                FourthLabel.Dispose ();
                FourthLabel = null;
            }

            if (SecondLabel != null) {
                SecondLabel.Dispose ();
                SecondLabel = null;
            }

            if (SeventhLabel != null) {
                SeventhLabel.Dispose ();
                SeventhLabel = null;
            }

            if (SixthLabel != null) {
                SixthLabel.Dispose ();
                SixthLabel = null;
            }

            if (ThirdLabel != null) {
                ThirdLabel.Dispose ();
                ThirdLabel = null;
            }
        }
    }
}