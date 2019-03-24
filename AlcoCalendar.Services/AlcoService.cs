using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlcoCalendar.LocalData;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.Models;
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

        public async Task<IList<AlcoItem>> ReadDay(Day day)
        {
            var result = await _localAlcoService.ReadDay(day).ConfigureAwait(false);
            return result?.AlcoItems
                .Select(x => new AlcoItem(x.AlcoBeverage) { Count = x.Count }).ToList();
        }

        public Task WriteDay(IList<AlcoItem> alcoItems, Day day)
        {
            return _localAlcoService.WriteDay(new AlcoDayDto(alcoItems, day));
        }
    }
}
