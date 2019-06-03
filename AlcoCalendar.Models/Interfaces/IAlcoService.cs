using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcoCalendar.Models.Interfaces
{
    public interface IAlcoService
    {
        Task WriteDay(IList<AlcoItem> alcoItem, Day day);

        Task<List<AlcoItem>> ReadDay(Day day);
    }
}
