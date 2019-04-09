using System;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.Common;

namespace AlcoCalendar.Droid.Views.Pages.AlcoDay
{
    public class AlcoDayAddViewHolder : RecyclerView.ViewHolder
    {
        private readonly Button _addButton;
        private WeakReferenceEx<AlcoDayViewModel> _viewModel;

        public AlcoDayAddViewHolder(View itemView) : base(itemView)
        {
            _addButton = itemView.FindViewById<Button>(Resource.Id.alco_add_button);
            _addButton.Click += AddButtonClick;
        }

        internal void Bind(AlcoDayViewModel viewModel)
        {
            _viewModel = new WeakReferenceEx<AlcoDayViewModel>(viewModel);
            _addButton.Text = viewModel.AddAlcoTitle;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            _viewModel.Target?.AddAlcoCommand.Execute(null);
        }
    }
}
