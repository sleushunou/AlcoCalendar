using System;
using Realms;

namespace AlcoCalendar.LocalData.Realm
{
    internal class LocalData : RealmObject
    {
        [PrimaryKey]
        public string Key { get; set; }

        public string Timestamp { get; set; }

        public string Data { get; set; }
    }
}
