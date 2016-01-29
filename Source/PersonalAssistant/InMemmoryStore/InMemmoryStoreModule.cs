using Autofac;

namespace PersonalAssistant.InMemmoryStore
{
    public class InMemmoryStoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new OpportunityRepository()).As<IOpportunityRepository>();
        }
    }
}