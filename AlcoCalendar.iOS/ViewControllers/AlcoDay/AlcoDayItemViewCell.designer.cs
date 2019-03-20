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

namespace AlcoCalendar.iOS.ViewControllers.AlcoDay
{
    [Register ("AlcoDayItemViewCell")]
    partial class AlcoDayItemViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CountTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NameButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CountTextField != null) {
                CountTextField.Dispose ();
                CountTextField = null;
            }

            if (NameButton != null) {
                NameButton.Dispose ();
                NameButton = null;
            }
        }
    }
}