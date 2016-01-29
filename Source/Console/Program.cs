using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PersonalAssistant;
using PersonalAssistant.Craigslist;
using PersonalAssistant.InMemmoryStore;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();
            Bootstrapper.Builder.RegisterModule<CraigslistModule>();

            Bootstrapper.SetAutofacContainer();
            var feed = Bootstrapper.Container.Resolve<IOpportunityFeed>();
            var repository = Bootstrapper.Container.Resolve<IOpportunityRepository>();

            var result = feed.Fetch();

            foreach (var opportunity in result)
            {
                repository.Save(opportunity);
            }

            var opportunities = repository.GetAll().ToArray();

            foreach (var opportunity in opportunities)
            {
                System.Console.WriteLine(opportunity.Title);
            }

            System.Console.ReadLine();
        }
    }
}
