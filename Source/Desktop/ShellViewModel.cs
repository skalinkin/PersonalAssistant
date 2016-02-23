using Caliburn.Micro;

namespace Desktop
{
    internal class ShellViewModel : PropertyChangedBase
    {
        private readonly IDesktopPlugin plugins;
        private object activeModule;
        private string name;

        public ShellViewModel(IDesktopPlugin plugins)
        {
            this.plugins = plugins;
            Modules.Add(new RetrievingModule.RetrievingModuleViewModel());
            ModulesButtons.Add(new ModuleButtonViewModel());
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public object ActiveModule
        {
            get { return activeModule; }
            set
            {
                activeModule = value;
                NotifyOfPropertyChange(() => ActiveModule);
            }
        }

        public BindableCollection<object> Modules { get; set; } = new BindableCollection<object>();
        public BindableCollection<object> ModulesButtons { get; set; } = new BindableCollection<object>();
    }
}