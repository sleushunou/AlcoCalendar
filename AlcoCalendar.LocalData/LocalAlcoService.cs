using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.LocalData.Realm;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Enum;
using Softeq.XToolkit.Common.Interfaces;
using RealmType = Realms.Realm;

namespace AlcoCalendar.LocalData
{
    public class LocalAlcoService : ILocalAlcoService
    {
        public Task<List<AlcoItem>> ReadDay(Day day)
        {
            return Task.Run(() =>
            {
                using (var realm = RealmType.GetInstance())
                {
                    List<AlcoItem> items = null;
                    try
                    {
                        var dto = realm.Find<AlcoDayDto>(AlcoDayDto.GetKey(day));
                        items = dto.AlcoItems.Select(x => new AlcoItem((AlcoBeverage)x.AlcoBeverage) { Count = x.Count }).ToList();
                    }
                    catch { }
                    return items;
                }
            });
        }

        public Task WriteDay(IList<AlcoItem> alcoItems, Day day)
        {
            return Task.Run(() =>
            {
                using (var realm = RealmType.GetInstance())
                {
                    return realm.WriteAsync((realmInstance) =>
                    {
                        realmInstance.Add(new AlcoDayDto(alcoItems, day), true);
                    });
                }
            });
        }
    }
}
