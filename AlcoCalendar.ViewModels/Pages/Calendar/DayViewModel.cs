using System;
using System.Linq;
using System.Threading.Tasks;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.ViewModels.Enums;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Softeq.XToolkit.Common.Extensions;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;
using Softeq.XToolkit.WhiteLabel.Threading;

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

        public Day Model { get; private set; }

        public DayOfWeek DayOfWeek => Model.DayOfWeek;

        public string DayNumber => Model.Number.ToString();

        public bool IsInSelectedMonth { get; private set; }

        public (Day, bool) Parameter
        {
            get => (Model, IsInSelectedMonth);
            set
            {
                Model = value.Item1;
                IsInSelectedMonth = value.Item2;
                LoadData().SafeTaskWrapper();
            }
        }

        private DayColor _color;
        public DayColor Color
        {
            get => _color;
            set => Set(ref _color, value);
        }

        private async Task LoadData()
        {
            var result = await _alcoService.ReadDay(Model).ConfigureAwait(false);

            if(result == null)
            {
                Color = DayColor.Default;
                return;
            }

            var alco = result.Sum(x => x.AlcoBeverage.GetDegree() * x.Count);
            Execute.BeginOnUIThread(() =>
            {
                if (alco > Constants.MaxAlcoInDay)
                {
                    Color = DayColor.Red;
                }
                else if (alco > 0 && alco < Constants.MaxAlcoInDay)
                {
                    Color = DayColor.Yellow;
                }
                else
                {
                    Color = DayColor.Default;
                }
            });
        }

        public async Task NavigateToDetailsAsync()
        {
            var result = await _dialogsService.ShowForViewModel<AlcoDayViewModel, DayViewModel>(this).ConfigureAwait(false);
            if (result != null)
            {
                await _alcoService.WriteDay(result.AlcoItems.Select(x => x.Model).ToList(), result.Parameter.Model).ConfigureAwait(false);
                await LoadData().ConfigureAwait(false);
            }
        }
    }
}
