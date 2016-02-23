using System;
using System.Collections.Generic;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using PersonalAssistant;
using PersonalAssistant.Craigslist;
using PersonalAssistant.InMemmoryStore;
using PersonalAssistant.MonkeyLearn;

namespace Desktop
{
    public class WpfBootstrapper : BootstrapperBase
    {
        private ILifetimeScope container;

        public WpfBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void Configure()
        {
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();
            Bootstrapper.Builder.RegisterModule<CraigslistModule>();
            Bootstrapper.Builder.RegisterModule<MonkeyLearnModule>();
            Bootstrapper.Builder.RegisterModule<DesktopModule>();
            Bootstrapper.SetAutofacContainer();
            container = Bootstrapper.Container.BeginLifetimeScope();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.Resolve(service);
        }

        protected override void BuildUp(object instance)
        {
            container.InjectProperties(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.Resolve(typeof (IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }
    }
}