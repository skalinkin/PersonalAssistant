using Autofac;

namespace PersonalAssistant.Craigslist
{
    public class CraigslistModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OpportunityFeed>().As<IOpportunityFeed>();
            builder.RegisterType<WebSiteFactory>().As<WebSiteFactory>();
        }
    }
}