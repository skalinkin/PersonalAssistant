using Autofac;

namespace PersonalAssistant.MonkeyLearn
{
    public class MonkeyLearnModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MonkeyLearnService>().As<IProbabilityService>();
        }
    }
}