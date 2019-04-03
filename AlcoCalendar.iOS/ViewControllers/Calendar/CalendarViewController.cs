using AlcoCalendar.ViewModels.Pages.Calendar;
using CoreGraphics;
using Foundation;
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Bindings.iOS;
using Softeq.XToolkit.Common;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.WhiteLabel.iOS;
using System;
using UIKit;

namespace AlcoCalendar.iOS.ViewControllers.Calendar
{
    public partial class CalendarViewController : ViewControllerBase<CalendarViewModel>
    {
        private const string cellReuseId = "dateCell";
        private const string headerReuseId = "calendarHeader";
        private const int cols = 7;

        private WeakReferenceEx<ObservableCollectionViewSource<DayViewModel, DayCell>> _source;

        public CalendarViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _source = new WeakReferenceEx<ObservableCollectionViewSource<DayViewModel, DayCell>>(ViewModel.Days.GetCollectionViewSource<DayViewModel, DayCell>(BindCell, GetSupplementaryView, cellReuseId));
            _source.Target.SelectionChanged += TargetSelectionChanged;
            CalendarCollectionView.Source = _source.Target;
            CalendarCollectionView.Delegate = new CalendarCollectionViewDelegateFlowLayout(_source);
            PrevButton.SetCommand(ViewModel.PrevCommand);
            NextButton.SetCommand(ViewModel.NextCommand);
        }

        protected override void DoAttachBindings()
        {
            base.DoAttachBindings();
            Bindings.Add(this.SetBinding(() => ViewModel.MonthAndYear, () => MonthAndYearLabel.Text));
        }

        private void BindCell(DayCell cell, DayViewModel item, NSIndexPath indexPath)
        {
            cell.BindCell(item);
        }

        private UICollectionReusableView GetSupplementaryView(NSString kind, NSIndexPath indexPath)
        {
            var header = (CalendarHeaderView)CalendarCollectionView.DequeueReusableSupplementaryView(kind, headerReuseId, indexPath);
            header.SetData(ViewModel.DaysOfWeek);
            return header;
        }

        private class CalendarCollectionViewDelegateFlowLayout : UICollectionViewDelegateFlowLayout
        {
            private readonly WeakReferenceEx<ObservableCollectionViewSource<DayViewModel, DayCell>> _source;

            public CalendarCollectionViewDelegateFlowLayout(WeakReferenceEx<ObservableCollectionViewSource<DayViewModel, DayCell>> source)
            {
                _source = source;
            }

            public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
            {
                nfloat width = (collectionView.Frame.Width - (layout as UICollectionViewFlowLayout).MinimumInteritemSpacing * (cols - 1))/cols;
                return new CGSize(width, width);
            }

            public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
            {
                _source.Target?.ItemSelected(collectionView, indexPath);
            }
        }

        private void TargetSelectionChanged(object sender, EventArgs e)
        {
            var viewModel = _source.Target?.SelectedItem;
            if(viewModel != null)
            {
                viewModel.NavigateToDetailsAsync();
            }
        }

    }
}