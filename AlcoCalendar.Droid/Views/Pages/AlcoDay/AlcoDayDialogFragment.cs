
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.WhiteLabel.Droid.Dialogs;
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Bindings.Droid;
using Android.Support.V7.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace AlcoCalendar.Droid.Views.Pages.AlcoDay
{
    public class AlcoDayDialogFragment : DialogFragmentBase<AlcoDayViewModel>
    {
        private TextView _titleTextView;
        private RecyclerView _alcoDayItemsTable;
        private Button _saveButton;

        public TextView TitleTextView => _titleTextView ?? (_titleTextView = View.FindViewById<TextView>(Resource.Id.alco_day_title));
        public RecyclerView AlcoDayItemsTable => _alcoDayItemsTable ?? (_alcoDayItemsTable = View.FindViewById<RecyclerView>(Resource.Id.alcoday_items_table));
        public Button SaveButton => _saveButton ?? (_saveButton = View.FindViewById<Button>(Resource.Id.save_button));

        protected override int ThemeId => Resource.Style.Theme_AppCompat_Light;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.alcoday, container, false);
        }

        protected override void DoAttachBindings()
        {
            base.DoAttachBindings();
            TitleTextView.Text = ViewModel.FullDate;

            var adapter = new AlcoDayAdapter (ViewModel.AlcoItems, GetViewHolder, BindViewHolder);
            AlcoDayItemsTable.SetLayoutManager(new LinearLayoutManager(Context));
            AlcoDayItemsTable.SetAdapter(adapter);

            SaveButton.SetCommand(ViewModel.DialogComponent.CloseCommand, true);
        }

        private ViewHolder GetViewHolder(ViewGroup parent, int viewType)
        {
            switch(viewType)
            {
                case -1:
                    {
                        var itemView = LayoutInflater.From(parent.Context)
                            .Inflate(Resource.Layout.alcoday_add_item, parent, false);
                        return new AlcoDayAddViewHolder(itemView);
                    }
                case 0:
                    {
                        var itemView = LayoutInflater.From(parent.Context)
                            .Inflate(Resource.Layout.alcoday_item, parent, false);
                        return new AlcoDayViewHolder(itemView, DeleteItem);
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        private void DeleteItem(AlcoDayItemViewModel viewModel)
        {
            ViewModel.AlcoItems.Remove(viewModel);
        }

        private void BindViewHolder(ViewHolder viewHolder, int viewType, AlcoDayItemViewModel dayViewModel)
        {
            if(viewType != -1)
            {
                ((AlcoDayViewHolder)viewHolder).Bind(dayViewModel);
            }
            else
            {
                ((AlcoDayAddViewHolder)viewHolder).Bind(ViewModel);
            }
        }

        private class AlcoDayAdapter : ObservableRecyclerViewAdapter<AlcoDayItemViewModel>
        {
            private readonly Action<ViewHolder, int, AlcoDayItemViewModel> _bindViewHolderAction;

            public AlcoDayAdapter(
                IList<AlcoDayItemViewModel> items, 
                Func<ViewGroup, int, ViewHolder> getHolderFunc, 
                Action<ViewHolder, int, AlcoDayItemViewModel> bindViewHolderAction) 
                    : base(items, getHolderFunc, bindViewHolderAction)
            {
                _bindViewHolderAction = bindViewHolderAction;
            }

            public override int ItemCount => base.ItemCount + 1;

            public override void OnBindViewHolder(ViewHolder holder, int position)
            {
                if(position != ItemCount - 1)
                {
                    base.OnBindViewHolder(holder, position);
                }
                else
                {
                    _bindViewHolderAction?.Invoke(holder, GetItemViewType(position), null);
                }
            }

            public override int GetItemViewType(int position)
            {
                if (position == ItemCount - 1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
