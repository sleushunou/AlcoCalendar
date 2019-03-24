using System;
using System.Threading.Tasks;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.Models;
using Softeq.XToolkit.Common.Interfaces;

namespace AlcoCalendar.LocalData
{
    public class LocalAlcoService : ILocalAlcoService
    {
        private readonly ILocalCache _localCache;
        private readonly IJsonSerializer _jsonSerializer;

        public LocalAlcoService(ILocalCache localCache, IJsonSerializer jsonSerializer)
        {
            _localCache = localCache;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<AlcoDayDto> ReadDay(Day day)
        {
            return await _localCache.Get<AlcoDayDto>(AlcoDayDto.GetKey(day)).ConfigureAwait(false);
        }

        public Task WriteDay(AlcoDayDto dto)
        {
            return _localCache.Add(dto.Key, DateTimeOffset.Now, dto);
        }
    }
}
