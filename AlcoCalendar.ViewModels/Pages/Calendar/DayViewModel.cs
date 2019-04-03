using System;
using System.Linq;
using System.Threading.Tasks;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.ViewModels.Pages.Calendar
{
    public class DayViewModel : ObservableObject, IViewModelParameter<(Day, bool)>
    {
        private readonly IDialogsService _dialogsService;
        private readonly IAlcoService _alcoService;

        public DayViewModel(IDialogsService dialogsService,
            IAlcoService alcoService)
        {
            _dialogsService = dialogsService;
            _alcoService = alcoService;
        }

        public Day Model => Parameter.Item1;

        public DayOfWeek DayOfWeek => Model.DayOfWeek;

        public string DayNumber => Model.Number.ToString();

        public bool IsInSelectedMonth => Parameter.Item2;

        public (Day, bool) Parameter { get; set; }

        public async Task NavigateToDetailsAsync()
        {
            var result = await _dialogsService.ShowForViewModel<AlcoDayViewModel, DayViewModel>(this).ConfigureAwait(false);
            if (result != null)
            {
                await _alcoService.WriteDay(result.AlcoItems.Select(x => x.Model).ToList(), result.Parameter.Model).ConfigureAwait(false);
            }
        }
    }
}
