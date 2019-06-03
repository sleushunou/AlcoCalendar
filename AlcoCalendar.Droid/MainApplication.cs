using System;
using System.Collections.Generic;
using System.Reflection;
using AlcoCalendar.Droid.Services;
using AlcoCalendar.LocalData;
using AlcoCalendar.LocalData.Interfaces;
using AlcoCalendar.Models;
using AlcoCalendar.Models.Interfaces;
using AlcoCalendar.Services;
using AlcoCalendar.ViewModels.Pages.AlcoDay;
using AlcoCalendar.ViewModels.Pages.AlcoList;
using AlcoCalendar.ViewModels.Pages.Calendar;
using AlcoCalendar.ViewModels.Pages.Start;
using Android.App;
using Android.Content;
using Android.Runtime;
using Autofac;
using Plugin.CurrentActivity;
using Softeq.XToolkit.Common.Interfaces;
using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.WhiteLabel.Droid;
using Softeq.XToolkit.WhiteLabel.Droid.Dialogs;
using Softeq.XToolkit.WhiteLabel.Droid.Navigation;
using Softeq.XToolkit.WhiteLabel.Droid.Services;
using Softeq.XToolkit.WhiteLabel.Droid.Services.Logger;
using Softeq.XToolkit.WhiteLabel.Extensions;
using Softeq.XToolkit.WhiteLabel.Interfaces;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;
using Softeq.XToolkit.WhiteLabel.Services;

namespace AlcoCalendar.Droid
{
    [Application]
    public class MainApplication : AutoRegistrationMainApplication
    {
        private IIocContainer _iocContainer;
        private ICurrentActivity _currentActivity;
        private ILocalizationService _localizationService;

        protected MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            _iocContainer = new IocContainer();
            _currentActivity = (new CurrentActivityImplementation());
            _currentActivity.Init(this);
            Dependencies.Initialize(_iocContainer);
            _localizationService = new DroidLocalizationService(ApplicationContext);
            Models.Resources.Current = new Resources(_localizationService);
            base.OnCreate();
        }

        protected override IList<Assembly> SelectAssemblies()
        {
            return new List<Assembly> { GetType().Assembly };
        }

        protected override void ConfigureIoc(ContainerBuilder builder)
        {
            builder.PerLifetimeScope<DroidConsoleLogManager, ILogManager>();
            builder.PerLifetimeScope<BackStackManager, IBackStackManager>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<PageNavigationService, IPageNavigationService>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.PerLifetimeScope<DroidFragmentDialogService, IDialogsService>()
                .WithParameter(new TypedParameter(typeof(IIocContainer), _iocContainer));
            builder.RegisterInstance(_localizationService).As<ILocalizationService>();
            builder.PerLifetimeScope<AlcoService, IAlcoService>();
            builder.PerLifetimeScope<LocalAlcoService, ILocalAlcoService>();
            builder.PerLifetimeScope<DefaultAlertBuilder, IAlertBuilder>();
            builder.PerLifetimeScope<ViewModelFactoryService, IViewModelFactoryService>();

            builder.PerLifetimeScope<JsonSerializer, IJsonSerializer>();

            builder.PerDependency<DayViewModel>();
        }
    }
}
