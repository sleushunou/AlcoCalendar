
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
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Common;

namespace AlcoCalendar.Droid.Views.Pages.Calendar
{
    public class DayViewHolder : RecyclerView.ViewHolder
    {
        private View _rootView;
        private TextView _dayTextView;
        private WeakReferenceEx<DayViewModel> _viewModel;
        private Binding _colorBinding;

        public DayViewHolder(View itemView) : base(itemView)
        {
            _rootView = itemView;
            _dayTextView = itemView.FindViewById<TextView>(Resource.Id.dayNumberTextView);
            itemView.Click += ItemViewClick;
        }

        internal void Bind(DayViewModel day)
        {
            _dayTextView.Text = day.DayNumber;
            _dayTextView.SetTextColor(day.IsInSelectedMonth ? Color.Black : Color.Gray);

            _viewModel = new WeakReferenceEx<DayViewModel>(day);

            _colorBinding?.Detach();
            _colorBinding = this.SetBinding(() => _viewModel.Target.Color).WhenSourceChanges(() =>
            {
                switch (day.Color)
                {
                    case ViewModels.Enums.DayColor.Red:
                        _rootView.Background = _rootView.Context.Resources.GetDrawable(Resource.Drawable.day_red, _rootView.Context.Theme);
                        break;
                    case ViewModels.Enums.DayColor.Yellow:
                        _rootView.Background = _rootView.Context.Resources.GetDrawable(Resource.Drawable.day_yellow, _rootView.Context.Theme);
                        break;
                    case ViewModels.Enums.DayColor.Default:
                        _rootView.Background = default;
                        break;
                }
            });
        }

        private void ItemViewClick(object sender, EventArgs e)
        {
            _viewModel.Target?.NavigateToDetailsAsync();
        }

    }
}
