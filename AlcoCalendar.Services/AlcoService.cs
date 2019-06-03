using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlcoCalendar.LocalData;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;
using AlcoCalendar.Models.Interfaces;

namespace AlcoCalendar.Services
{
    public class AlcoService : IAlcoService
    {
        private readonly ILocalAlcoService _localAlcoService;

        public AlcoService(ILocalAlcoService localAlcoService)
        {
            _localAlcoService = localAlcoService;
        }

        public Task<List<AlcoItem>> ReadDay(Day day)
        {
            return _localAlcoService.ReadDay(day);
        }

        public Task WriteDay(IList<AlcoItem> alcoItems, Day day)
        {
            return _localAlcoService.WriteDay(alcoItems, day);
        }
    }
}
