using System.Collections.Generic;
using System.Reflection;
using Foundation;
using Softeq.XToolkit.WhiteLabel.iOS;
using UIKit;
using Autofac;
using AlcoCalendar.ViewModels.Pages.Start;
using Softeq.XToolkit.WhiteLabel.Extensions;
using Softeq.XToolkit.WhiteLabel.Navigation;
using Softeq.XToolkit.WhiteLabel.iOS.Navigation;
using Softeq.XToolkit.WhiteLabel.iOS.Services;
using System;
using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.Common.Interfaces;
using Softeq.XToolkit.WhiteLabel.iOS.Services.Logger;
using AlcoCalendar.ViewModels.Pages.Calendar;
using Softeq.XToolkit.Bindings;
using Softeq.XToolkit.Bindings.iOS;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using AlcoCalendar.Models;
using AlcoCalendar.iOS.Services;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.ViewModels.Pages.AlcoList;
using Softeq.XToolkit.Caching.Realm;
using AlcoCalendar.Services;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.LocalData;
using Softeq.XToolkit.WhiteLabel.Services;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.Permissions;
using Softeq.XToolkit.Permissions.iOS;

namespace AlcoCalendar.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : AutoRegistrationAppDelegate
    {
        private IIocContainer _iocContainer;
        private ILocalizationService _localiztionService;

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _iocContainer = new IocContainer();
            Dependencies.Initialize(_iocContainer);
            BindingExtensions.Initialize(new AppleBindingFactory());

            _localiztionService = new IOSLocalizationService();
            Resources.Current = new Resources(_localiztionService);

            var result = base.FinishedLaunching(application, launchOptions);
            return result;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        protected override void ConfigureIoc(ContainerBuilder builder)
        {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
            builder.PerLifetimeScope<IosConsoleLogManager, ILogManager>();
            builder.PerLifetimeScope<BackStackManager, IBackStackManager>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<PageNavigationService, IPageNavigationService>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<StoryboardDialogsService, IDialogsService>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.RegisterInstance(_localiztionService);
            builder.PerLifetimeScope<RealmLocalCache, ILocalCache>();
            builder.PerLifetimeScope<AlcoService, IAlcoService>();
            builder.PerLifetimeScope<LocalAlcoService, ILocalAlcoService>();
            builder.PerLifetimeScope<ViewModelFactoryService, IViewModelFactoryService>();

            builder.PerLifetimeScope<JsonSerializer, IJsonSerializer>();

            builder.PerDependency<StartPageViewModel>();
            builder.PerDependency<CalendarViewModel>();
            builder.PerDependency<AlcoDayViewModel>();
            builder.PerDependency<AlcoListViewModel>();
            builder.PerDependency<DayViewModel>();
#pragma warning restore CS1701 // Assuming assembly reference matches identity
        }

        protected override IList<Assembly> SelectAssemblies()
        {
            return new List<Assembly> { GetType().Assembly };
        }
    }
}

