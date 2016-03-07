using Autofac;

namespace Desktop.RetrievingModule
{
    internal class RetrievingDesktopPluginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RetrievingDesktopPlugin>().As<IDesktopPlugin>();
        }
    }
}