using AlcoCalendar.Models.Interfaces;
using Foundation;

namespace AlcoCalendar.iOS.Services
{
    public class IOSLocalizationService : ILocalizationService
    {
        public string GetLocalizableStirng(string key)
        {
            return NSBundle.MainBundle.GetLocalizedString(key);
        }
    }
}
