using System.Linq;
using Autofac;
using PersonalAssistant;
using PersonalAssistant.Entities;

namespace Console.Commands
{
    internal class DiscoverCommand : Command
    {
        public override void Execute()
        {
            var feed = Bootstrapper.Container.Resolve<IOpportunityFeed>();
            var repository = Bootstrapper.Container.Resolve<OpportunityRepository>();

            var result = feed.FetchNew();

            foreach (var opportunity in result)
            {
                opportunity.Resolution = Resolution.New;
                repository.Save(opportunity);
                System.Console.WriteLine("Discovered: {0}", opportunity.Title);
            }
        }
    }
}