using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Foundation;
using Softeq.XToolkit.WhiteLabel.iOS;
using System;
using Softeq.XToolkit.Bindings;
using UIKit;
using Softeq.XToolkit.Common;
using Softeq.XToolkit.Bindings.iOS;
using System.Diagnostics;

namespace AlcoCalendar.iOS.ViewControllers.AlcoDay
{
    public partial class AlcoDayViewController : ViewControllerBase<AlcoDayViewModel>
    {
        private const string cellIdentifier = "alcoItemCell";
        private const string insertCellIdentifier = "insertCell";

        private WeakReferenceEx<AlcoItemsTableViewSource> _source;

        public AlcoDayViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TopNavigationBar.LeftBarButtonItem.SetCommand(ViewModel.DialogComponent.CloseCommand);
            TopNavigationBar.RightBarButtonItem.SetCommand(ViewModel.DialogComponent.CloseCommand, true);
            TopNavigationBar.Title = ViewModel.FullDate;
            _source = new WeakReferenceEx<AlcoItemsTableViewSource>(new AlcoItemsTableViewSource(ViewModel.AddAlcoTitle)
            {
                DataSource = ViewModel.AlcoItems,
                BindCellDelegate = BindCell
            });
            Table.Source = _source.Target;
            Table.SetEditing(true, false);
            Table.AllowsSelectionDuringEditing = true;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            _source.Target.AddRowPressed += TargetAddRowPressed;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _source.Target.AddRowPressed -= TargetAddRowPressed;
        }

        private void TargetAddRowPressed()
        {
            ViewModel.AddAlcoCommand.Execute(null);
        }

        private void BindCell(UITableViewCell cell, AlcoDayItemViewModel item, NSIndexPath indexPath)
        {
            ((AlcoDayItemViewCell)cell).BindCell(item);
        }

        private class AlcoItemsTableViewSource : ObservableTableViewSource<AlcoDayItemViewModel>
        {
            private readonly string _addTitle;

            public AlcoItemsTableViewSource(string addTitle)
            {
                _addTitle = addTitle;
            }

            public event Action AddRowPressed;

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = null;
                if (indexPath.Row == RowsInSection(tableView, indexPath.Section) - 1)
                {
                    cell = tableView.DequeueReusableCell(insertCellIdentifier);
                    if (cell == null)
                    {
                        cell = new UITableViewCell(UITableViewCellStyle.Default, insertCellIdentifier);
                        cell.TextLabel.Text = _addTitle;
                    }
                }
                else
                {
                    cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
                    try
                    {
                        var coll = DataSource;

                        if (coll != null)
                        {
                            var item = coll[indexPath.Row];
                            BindCell(cell, item, indexPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return base.RowsInSection(tableview, section) + 1;
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return 50;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);
                if (indexPath.Row == RowsInSection(tableView, indexPath.Section) - 1)
                {
                    AddRowPressed?.Invoke();
                }
            }

            public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
            {
                if (indexPath.Row == RowsInSection(tableView, indexPath.Section) - 1)
                {
                    return UITableViewCellEditingStyle.Insert;
                }

                return UITableViewCellEditingStyle.Delete;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    AddRowPressed?.Invoke();
                }
                else if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    DataSource.RemoveAt(indexPath.Row);
                }
            }
        }
    }
}