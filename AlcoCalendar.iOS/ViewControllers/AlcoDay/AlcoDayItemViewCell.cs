using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Softeq.XToolkit.Bindings;
using System;
using UIKit;

namespace AlcoCalendar.iOS.ViewControllers.AlcoDay
{
    public partial class AlcoDayItemViewCell : UITableViewCell
    {
        private Binding _countBinding;
        private AlcoDayItemViewModel _viewModel;

        public AlcoDayItemViewCell (IntPtr handle) : base (handle)
        {
        }

        internal void BindCell(AlcoDayItemViewModel item)
        {
            _viewModel = item;
            NameButton.SetTitle(_viewModel.Name, UIControlState.Normal);

            _countBinding?.Detach();
            _countBinding = this.SetBinding(() => _viewModel.CountString, () => CountTextField.Text, BindingMode.TwoWay);
        }
    }
}