using System;
using System.Threading.Tasks;
using AlcoCalendar.Models;

namespace AlcoCalendar.LocalData.Interfaces
{
    public interface ILocalAlcoService
    {
       Task WriteDay(AlcoDayDto dto); 

       Task<AlcoDayDto> ReadDay(Day day);
    }
}
