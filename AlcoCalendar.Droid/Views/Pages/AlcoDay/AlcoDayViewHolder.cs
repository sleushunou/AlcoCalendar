using System;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Common;

namespace AlcoCalendar.Droid.Views.Pages.AlcoDay
{
    public class AlcoDayViewHolder : RecyclerView.ViewHolder
    {
        private readonly Button _nameButton;
        private readonly ImageButton _deleteButton;
        private readonly TextInputEditText _editText;

        private WeakReferenceEx<AlcoDayItemViewModel> _viewModel;
        private Binding _nameBinding;
        private Binding _countBinding;
        private WeakAction<AlcoDayItemViewModel> _deleteAction;

        public AlcoDayViewHolder(View itemView, Action<AlcoDayItemViewModel> deleteActopm) : base(itemView)
        {
            _nameButton = itemView.FindViewById<Button>(Resource.Id.button_name);
            _deleteButton = itemView.FindViewById<ImageButton>(Resource.Id.button_alcodayitem_delete);
            _editText = itemView.FindViewById<TextInputEditText>(Resource.Id.edittext_count);
            _deleteButton.Click += DeleteButtonClick;
            _deleteAction = new WeakAction<AlcoDayItemViewModel>(deleteActopm);
        }

        internal void Bind(AlcoDayItemViewModel viewModel)
        {
            _viewModel = new WeakReferenceEx<AlcoDayItemViewModel>(viewModel);

            _nameBinding?.Detach();
            _nameBinding = this.SetBinding(() => _viewModel.Target.Name, () => _nameButton.Text);

            _countBinding?.Detach();
            _countBinding = this.SetBinding(() => _viewModel.Target.CountString, () => _editText.Text, BindingMode.TwoWay);
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            _deleteAction.ExecuteWithObject(_viewModel.Target);
        }
    }
}
