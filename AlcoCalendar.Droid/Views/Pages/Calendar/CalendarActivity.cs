
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlcoCalendar.ViewModels.Pages.Calendar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.Bindings;
using Android.Support.V7.Widget;
using Softeq.XToolkit.Bindings.Droid;
using static Android.Support.V7.Widget.RecyclerView;
using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.Droid.Views.Pages.Calendar
{
    [Activity]
    public class CalendarActivity : ActivityBase<CalendarViewModel>
    {
        private TextView _monthAndYearTextView;
        private RecyclerView _calenarRecyclerView;
        private Button _prevButton;
        private Button _nextButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.calendar);
            _prevButton = FindViewById<Button>(Resource.Id.prevButton);
            _nextButton = FindViewById<Button>(Resource.Id.nextButton);
            _monthAndYearTextView = FindViewById<TextView>(Resource.Id.monthAndYearTextView);
            _calenarRecyclerView = FindViewById<RecyclerView>(Resource.Id.calendarRecyclerView);
            _calenarRecyclerView.SetLayoutManager(new GridLayoutManager(this, 7));

            var adapter = new ObservableRecyclerViewAdapter<DayViewModel>(ViewModel.Days, GetViewHolder, BindViewHolder);
            _calenarRecyclerView.SetAdapter(adapter);
        }

        private ViewHolder GetViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.day, parent, false);

            return new DayViewHolder(itemView);
        }

        private void BindViewHolder(ViewHolder viewHolder, int viewType, DayViewModel dayViewModel)
        {
            ((DayViewHolder)viewHolder).Bind(dayViewModel);
        }

        protected override void DoAttachBindings()
        {
            base.DoAttachBindings();
            Bindings.Add(this.SetBinding(() => ViewModel.MonthAndYear, () => _monthAndYearTextView.Text));
            _prevButton.SetCommand(ViewModel.PrevCommand);
            _nextButton.SetCommand(ViewModel.NextCommand);
        }
    }
}
