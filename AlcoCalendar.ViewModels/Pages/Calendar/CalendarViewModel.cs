using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.Common.Command;
using Softeq.XToolkit.Common.Extensions;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace AlcoCalendar.ViewModels.Pages.Calendar
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly IViewModelFactoryService _viewModelFactoryService;

        private Month _month;
        private string _monthAndYear;

        public CalendarViewModel(IViewModelFactoryService viewModelFactoryService)
        {
            _viewModelFactoryService = viewModelFactoryService;

            Days = new ObservableRangeCollection<DayViewModel>();
            DaysOfWeek = GetOrderedDaysOfWeek()
                .Select(CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName).ToArray();

            PrevCommand = new RelayCommand(ActionLoadPrevMonth);
            NextCommand = new RelayCommand(ActionLoadNextMont);

            LoadMonth(new Year(DateTime.Now.Year).Months.First(x => x.Number == DateTime.Now.Month));
        }

        public string[] DaysOfWeek { get; }

        public ObservableRangeCollection<DayViewModel> Days { get; }

        public RelayCommand PrevCommand { get; }

        public RelayCommand NextCommand { get; }

        public string MonthAndYear
        {
            get => _monthAndYear;
            set { Set(() => MonthAndYear, ref _monthAndYear, value); }
        }

        private void LoadMonth(Month month)
        {
            _month = month;

            MonthAndYear = new DateTime(month.Year.Number, month.Number, 1).ToString("Y");

            var days = new List<DayViewModel>();

            int prevMonthDayCount = (int)month.Days.First().DayOfWeek;
            if (prevMonthDayCount > 0)
            {
                var prevMonthDays = GetPrevMonth().Days;
                days.AddRange(prevMonthDays.Skip(prevMonthDays.Count - prevMonthDayCount)
                    .Select(x => _viewModelFactoryService.ResolveViewModel<DayViewModel, (Day, bool)>((x, false))));
            }

            days.AddRange(month.Days
                .Select(x => _viewModelFactoryService.ResolveViewModel<DayViewModel, (Day, bool)>((x, true))));

            int nextMonthDayCount = (int)(GetOrderedDaysOfWeek().Last() - (int)month.Days.Last().DayOfWeek);
            if (nextMonthDayCount > 0)
            {
                var nextMonthDays = GetNextMonth().Days;
                days.AddRange(nextMonthDays.Take(nextMonthDayCount)
                    .Select(x => _viewModelFactoryService.ResolveViewModel<DayViewModel, (Day, bool)>((x, false))));
            }

            if (Days.Count > 0) //TODO replace to clear after framework fix
            {
                Days.RemoveRange(Days.ToList(), System.Collections.Specialized.NotifyCollectionChangedAction.Remove);
            }
            Days.AddRange(new List<DayViewModel>(days));
        }

        private void ActionLoadPrevMonth()
        {
            LoadMonth(GetPrevMonth());
        }

        private void ActionLoadNextMont()
        {
            LoadMonth(GetNextMonth());
        }

        private Month GetPrevMonth()
        {
            return _month.Number == 1 ? new Year(_month.Year.Number - 1).Months.Last() : _month.Year.Months.First(x => x.Number == _month.Number - 1);
        }

        private Month GetNextMonth()
        {
            return _month.Number == 12 ? new Year(_month.Year.Number + 1).Months.First() : _month.Year.Months.First(x => x.Number == _month.Number + 1);
        }

        private DayOfWeek[] GetOrderedDaysOfWeek()
        {
            return (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));
        }
    }
}
