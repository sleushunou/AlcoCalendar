using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlcoCalendar.Models;

namespace AlcoCalendar.LocalData.Interfaces
{
    public interface ILocalAlcoService
    {
       Task WriteDay(IList<AlcoItem> alcoItems, Day day); 

       Task<List<AlcoItem>> ReadDay(Day day);
    }
}
