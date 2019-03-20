using AlcoCalendar.ViewModels.Pages.AlcoList;
using Foundation;
using Softeq.XToolkit.WhiteLabel.iOS;
using Softeq.XToolkit.Bindings;
using System;
using UIKit;
using Softeq.XToolkit.Bindings.iOS;
using Softeq.XToolkit.Common;

namespace AlcoCalendar.iOS.ViewControllers.AlcoDay
{
    public partial class AlcoListViewController : ViewControllerBase<AlcoListViewModel>
    {
        private const string cellReuseId = "alcoItemCell";

        private WeakReferenceEx<ObservableTableViewSource<AlcoListItemViewModel>> _source;

        public AlcoListViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TopNavigationBar.LeftBarButtonItem.SetCommand(ViewModel.DialogComponent.CloseCommand);
            TopNavigationBar.RightBarButtonItem.SetCommand(ViewModel.DialogComponent.CloseCommand);
            _source = new WeakReferenceEx<ObservableTableViewSource<AlcoListItemViewModel>>(ViewModel.AlcoListItemViewModels.GetTableViewSource(
                (identifier) => { return new UITableViewCell(UITableViewCellStyle.Default, identifier); },
                BindCell,
                cellReuseId));
            Table.Source = _source.Target;
        }

        protected override void DoAttachBindings()
        {
            base.DoAttachBindings();
            Bindings.Add(this.SetBinding(() => ViewModel.SelectedItem, () => _source.Target.SelectedItem, BindingMode.TwoWay));
        }

        private void BindCell(UITableViewCell cell, AlcoListItemViewModel item, NSIndexPath indexPath)
        {
            cell.TextLabel.Text = item.Name;
            cell.Accessory = item.IsSelected ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
        }
    }
}