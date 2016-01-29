using Autofac;
using PersonalAssistant;
using PersonalAssistant.Craigslist;
using PersonalAssistant.InMemmoryStore;

namespace Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();
            Bootstrapper.Builder.RegisterModule<CraigslistModule>();

            Bootstrapper.SetAutofacContainer();
            var feed = Bootstrapper.Container.Resolve<IOpportunityFeed>();
            var repository = Bootstrapper.Container.Resolve<IOpportunityRepository>();

            var result = feed.FetchNew();

            foreach (var opportunity in result)
            {
                repository.Save(opportunity);
            }

            foreach (var opportunity in repository.FindAll())
            {
                System.Console.WriteLine("{0}, {1}",opportunity.Title, opportunity.OriginalSourceId);
            }

            System.Console.ReadLine();
        }
    }
}