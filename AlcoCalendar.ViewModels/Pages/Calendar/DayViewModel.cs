using System;
using AlcoCalendar.Models;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace AlcoCalendar.ViewModels.Pages.Calendar
{
    public class DayViewModel : ObservableObject
    {
        private string _day;
        private bool _isInSelectedMonth;

        public DayViewModel(Day day, bool isInSelectedMonth)
        {
            DayOfWeek = day.DayOfWeek;
            Day = day.Number.ToString();
            IsInSelectedMonth = isInSelectedMonth;
        }

        public DayOfWeek DayOfWeek { get; }

        public string Day
        {
            get => _day;
            set => Set(() => Day, ref _day, value);
        }

        public bool IsInSelectedMonth
        {
            get => _isInSelectedMonth;
            set => Set(() => IsInSelectedMonth, ref _isInSelectedMonth, value);
        }
    }
}
