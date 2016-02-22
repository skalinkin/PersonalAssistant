using Caliburn.Micro;

namespace Desktop
{
    public class ShellViewModel : PropertyChangedBase
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
    }
}