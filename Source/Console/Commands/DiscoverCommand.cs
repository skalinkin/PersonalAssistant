using Common.Logging;
using PersonalAssistant;
using PersonalAssistant.Entities;

namespace Console.Commands
{
    internal class DiscoverCommand : Command
    {
        private readonly IOpportunityFeed feed;
        private readonly ILog logger;
        private readonly OpportunityRepository repository;

        public DiscoverCommand(ILog logger, IOpportunityFeed feed, OpportunityRepository repository)
        {
            this.logger = logger;
            this.feed = feed;
            this.repository = repository;
        }

        public override void Execute(object opt)
        {
            logger.Info("Starting Discovery.");

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