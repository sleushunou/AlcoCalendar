using System;
using System.Collections.Generic;
using System.Linq;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.ViewModels.Pages.AlcoList;
using AlcoCalendar.ViewModels.Pages.Calendar;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.Common.Command;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.ViewModels.Pages.AlcoDay
{
    public class AlcoDayViewModel : ViewModelBase, IDialogViewModel, IViewModelParameter<DayViewModel>
    {
        private readonly IDialogsService _dialogsService;
        private readonly ILocalizationService _localizationService;

        public AlcoDayViewModel(IDialogsService dialogsService,
            ILocalizationService localizationService)
        {
            _localizationService = localizationService;
            _dialogsService = dialogsService;

            AlcoItems = new ObservableRangeCollection<AlcoDayItemViewModel>();
            AddAlcoCommand = new RelayCommand(AddAlcoActionAsync);
            DialogComponent = new DialogViewModelComponent(this);
        }

        public ObservableRangeCollection<AlcoDayItemViewModel> AlcoItems { get; }

        public RelayCommand AddAlcoCommand { get; }

        public DialogViewModelComponent DialogComponent { get; }

        public DayViewModel Parameter { get; set; }

        public string FullDate => new DateTime(Parameter.Model.Month.Year.Number, Parameter.Model.Month.Number, Parameter.Model.Number).ToString("D");

        public string AddAlcoTitle => Resources.Current.AddAlcohol;

        private async void AddAlcoActionAsync()
        {
            var result = await _dialogsService.ShowForViewModel<AlcoListViewModel, IList<AlcoBeverage>>(AlcoItems.Select(x => x.Model).ToList()).ConfigureAwait(false);
            if(result?.SelectedItem != null)
            {
                AlcoItems.Add(new AlcoDayItemViewModel(result.SelectedItem.Model, _localizationService));
            }
        }
    }
}
