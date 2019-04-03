
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlcoCalendar.ViewModels.Pages.Calendar;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.Common;

namespace AlcoCalendar.Droid.Views.Pages.Calendar
{
    public class DayViewHolder : RecyclerView.ViewHolder
    {
        private TextView _dayTextView;
        private WeakReferenceEx<DayViewModel> _viewModel;

        public DayViewHolder(View itemView) : base(itemView)
        {
            _dayTextView = itemView.FindViewById<TextView>(Resource.Id.dayNumberTextView);
            itemView.Click += ItemViewClick;
        }

        internal void Bind(DayViewModel day)
        {
            _dayTextView.Text = day.DayNumber;
            _dayTextView.SetTextColor(day.IsInSelectedMonth ? Color.Black : Color.Gray);

            _viewModel = new WeakReferenceEx<DayViewModel>(day);
        }

        private void ItemViewClick(object sender, EventArgs e)
        {
            _viewModel.Target?.NavigateToDetailsAsync();
        }

    }
}
