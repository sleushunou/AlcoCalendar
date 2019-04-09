using System;
using AlcoCalendar.ViewModels.Pages.AlcoList;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Bindings.Droid;
using Softeq.XToolkit.WhiteLabel.Droid.Dialogs;
using static Android.Support.V7.Widget.RecyclerView;

namespace AlcoCalendar.Droid.Views.Pages.AlcoList
{
    public class AlcoListDialogFragment : DialogFragmentBase<AlcoListViewModel>
    {
        private ListView _alcoDayItemsTable;

        public ListView AlcoDayItemsTable => _alcoDayItemsTable ?? (_alcoDayItemsTable = View.FindViewById<ListView>(Resource.Id.alco_list_recyclerView));
        protected override int ThemeId => Resource.Style.Theme_AppCompat_Light;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.alco_list, container, false);
        }

        protected override void DoAttachBindings()
        {
            base.DoAttachBindings();

            AlcoDayItemsTable.Adapter = ViewModel.AlcoListItemViewModels.GetAdapter(GetTemplate);
            AlcoDayItemsTable.ItemClick += AlcoDayItemsTableItemClick;
        }

        private View GetTemplate(int position, AlcoListItemViewModel item, View view)
        {
            var cell = view ?? Activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            cell.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            return cell;
        }

        private void AlcoDayItemsTableItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ViewModel.SelectedItem = ViewModel.AlcoListItemViewModels[e.Position];
        }
    }
}
