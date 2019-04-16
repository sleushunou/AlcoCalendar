﻿using System;
using System.Globalization;
using System.Threading.Tasks;
using Softeq.XToolkit.Common.Interfaces;
using RealmType = Realms.Realm;

namespace AlcoCalendar.LocalData.Realm
{
    public class RealmLocalCache : ILocalCache
    {
        private readonly IJsonSerializer _jsonSerializer;

        public RealmLocalCache(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public Task<T> Get<T>(string key)
        {
            return Task.Run(() =>
            {
                using (var realm = RealmType.GetInstance())
                {
                    var result = realm.Find<LocalData>(key);
                    return result == null ? default(T) : _jsonSerializer.Deserialize<T>(result.Data);
                }
            });
        }

        public Task<DateTimeOffset?> GetExpiration(string key)
        {
            return Task.Run(() =>
            {
                using (var realm = RealmType.GetInstance())
                {
                    var result = realm.Find<LocalData>(key);
                    if (result == null)
                    {
                        return default(DateTimeOffset?);
                    }

                    return DateTimeOffset.Parse(result.Timestamp, CultureInfo.InvariantCulture) as DateTimeOffset?;
                }
            });
        }

        public Task Add(string key, DateTimeOffset date, object obj)
        {
            return Task.Run(() =>
            {
                var json = _jsonSerializer.Serialize(obj);
                var localData = new LocalData
                {
                    Data = json,
                    Timestamp = date.ToString("r"),
                    Key = key
                };
                using (var realm = RealmType.GetInstance())
                {
                    realm.Write(() =>
                    {
                        realm.Add(localData, true);
                    });
                }
            });
        }

        public Task<bool> Exists(string key)
        {
            return Task.Run(() =>
            {
                using (var realm = RealmType.GetInstance())
                {
                    var result = realm.Find<LocalData>(key);
                    return result != null;
                }
            });
        }

        public async Task<bool> IsExpired(string key)
        {
            var time = await GetExpiration(key);
            if (time.HasValue)
            {
                return DateTimeOffset.UtcNow > time.Value;
            }
            return true;
        }

        public void Reset()
        {
            Task.Run(() =>
            {
                using (var realm = RealmType.GetInstance())
                {
                    realm.RemoveAll();
                }
            });
        }
    }
}
