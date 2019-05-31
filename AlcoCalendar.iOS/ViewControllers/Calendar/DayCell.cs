using AlcoCalendar.ViewModels.Pages.Calendar;
using Foundation;
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Common;
using System;
using UIKit;

namespace AlcoCalendar.iOS.ViewControllers.Calendar
{
    public partial class DayCell : UICollectionViewCell
    {
        private Binding _colorBinding;
        private WeakReferenceEx<DayViewModel> _viewModel;

        public DayCell (IntPtr handle) : base (handle)
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            Layer.CornerRadius = Bounds.Height / 2;
            Layer.MasksToBounds = true;
        }

        internal void BindCell(DayViewModel item)
        {
            NumberLabel.Text = item.DayNumber;
            NumberLabel.TextColor = item.IsInSelectedMonth ?
                UIColor.Black : UIColor.Gray;

            _viewModel = new WeakReferenceEx<DayViewModel>(item);

            _colorBinding?.Detach();
            _colorBinding = this.SetBinding(() => _viewModel.Target.Color).WhenSourceChanges(() =>
            {
                switch (_viewModel.Target.Color)
                {
                    case ViewModels.Enums.DayColor.Red:
                        BackgroundColor = UIColor.Red;
                        break;
                    case ViewModels.Enums.DayColor.Yellow:
                        BackgroundColor = UIColor.Yellow;
                        break;
                    case ViewModels.Enums.DayColor.Default:
                        BackgroundColor = UIColor.Clear;
                        break;
                }
            });
        }
    }
}