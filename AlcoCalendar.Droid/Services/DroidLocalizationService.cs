using System;
using AlcoCalendar.Models.Interfaces;
using Android.Content;

namespace AlcoCalendar.Droid.Services
{
    public class DroidLocalizationService : ILocalizationService
    {
        private readonly Context _context;

        public DroidLocalizationService(Context context)
        {
            _context = context;
        }

        public string GetLocalizableStirng(string key)
        {
            return _context.Resources.GetString(_context.Resources.GetIdentifier(key, "string", _context.PackageName));
        }
    }
}
