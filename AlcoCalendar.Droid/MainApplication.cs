﻿using System;
using System.Collections.Generic;
using System.Reflection;
using AlcoCalendar.Droid.Services;
using AlcoCalendar.LocalData;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.Services;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using AlcoCalendar.ViewModels.Pages.AlcoList;
using AlcoCalendar.ViewModels.Pages.Calendar;
using AlcoCalendar.ViewModels.Pages.Start;
using Android.App;
using Android.Runtime;
using Autofac;
using Plugin.CurrentActivity;
using Softeq.XToolkit.Caching.Realm;
using Softeq.XToolkit.Common.Interfaces;
using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.WhiteLabel.Droid.Dialogs;
using Softeq.XToolkit.WhiteLabel.Droid.Navigation;
using Softeq.XToolkit.WhiteLabel.Droid.Services;
using Softeq.XToolkit.WhiteLabel.Droid.Services.Logger;
using Softeq.XToolkit.WhiteLabel.Extensions;
using Softeq.XToolkit.WhiteLabel.Navigation;
using Softeq.XToolkit.WhiteLabel.Services;

namespace AlcoCalendar.Droid
{
    [Application]
    public class MainApplication : MainApplicationBase
    {
        private IIocContainer _iocContainer;
        private ICurrentActivity _currentActivity;

        protected MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            _iocContainer = new IocContainer();
            _currentActivity = (new CurrentActivityImplementation());
            _currentActivity.Init(this);
            Dependencies.Initialize(_iocContainer);
            base.OnCreate();
        }

        public override IList<Assembly> SelectAssemblies()
        {
            return new List<Assembly> { GetType().Assembly };
        }

        protected override void ConfigureIoc(ContainerBuilder builder)
        {
            builder.PerLifetimeScope<ActivityPageNavigationService, IPlatformNavigationService>()
                .WithParameter(new TypedParameter(typeof(ICurrentActivity), _currentActivity))
                .PreserveExistingDefaults();

            builder.RegisterType<ViewLocator>();
            builder.PerLifetimeScope<DroidConsoleLogManager, ILogManager>();
            builder.PerLifetimeScope<BackStackManager, IBackStackManager>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<PageNavigationService, IPageNavigationService>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<DroidFragmentDialogService, IDialogsService>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<DroidLocalizationService, ILocalizationService>();
            builder.PerLifetimeScope<RealmLocalCache, ILocalCache>();
            builder.PerLifetimeScope<AlcoService, IAlcoService>();
            builder.PerLifetimeScope<LocalAlcoService, ILocalAlcoService>();
            builder.PerLifetimeScope<DefaultAlertBuilder, IAlertBuilder>();

            builder.PerLifetimeScope<JsonSerializer, IJsonSerializer>();

            builder.PerDependency<StartPageViewModel>();
            builder.PerDependency<CalendarViewModel>();
            builder.PerDependency<AlcoDayViewModel>();
            builder.PerDependency<AlcoListViewModel>();
        }
    }
}
