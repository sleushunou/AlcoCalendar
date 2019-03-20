using System;
using AlcoCalendar.Models;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace AlcoCalendar.ViewModels.Pages.Calendar
{
    public class DayViewModel : ObservableObject
    {
        private bool _isInSelectedMonth;

        public DayViewModel(Day day, bool isInSelectedMonth)
        {
            Model = day;
            IsInSelectedMonth = isInSelectedMonth;
        }

        public Day Model { get; }

        public DayOfWeek DayOfWeek => Model.DayOfWeek;

        public string DayNumber => Model.Number.ToString();

        public bool IsInSelectedMonth
        {
            get => _isInSelectedMonth;
            set => Set(() => IsInSelectedMonth, ref _isInSelectedMonth, value);
        }
    }
}
