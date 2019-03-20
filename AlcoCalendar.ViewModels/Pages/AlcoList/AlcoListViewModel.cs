using System;
using System.Collections.Generic;
using System.Linq;
using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.ViewModels.Pages.AlcoList
{
    public class AlcoListViewModel : ViewModelBase, IDialogViewModel, IViewModelParameter<IList<AlcoBeverage>>
    {
        private readonly ILocalizationService _localizationService;

        private AlcoListItemViewModel _selectedItem;

        public AlcoListViewModel(ILocalizationService localizationService)
        {
            _localizationService = localizationService;

            DialogComponent = new DialogViewModelComponent(this);
            AlcoListItemViewModels = new ObservableRangeCollection<AlcoListItemViewModel>();
        }

        public ObservableRangeCollection<AlcoListItemViewModel> AlcoListItemViewModels { get; }

        public DialogViewModelComponent DialogComponent { get; }

        public IList<AlcoBeverage> Parameter { get; set; }

        public AlcoListItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(() => SelectedItem, ref _selectedItem, value);
                DialogComponent.CloseCommand.Execute(true);
            }
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            AlcoListItemViewModels.AddRange(
            ((AlcoBeverage[])Enum.GetValues(typeof(AlcoBeverage)))
                .Except(Parameter)
                .Select(x => new AlcoListItemViewModel(x, _localizationService)));
        }
    }
}
