using System;
using System.Linq;
using Autofac;
using PersonalAssistant;
using PersonalAssistant.Craigslist;
using PersonalAssistant.Entities;
using PersonalAssistant.InMemmoryStore;

namespace Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteMessage("Initializing...");
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();
            Bootstrapper.Builder.RegisterModule<CraigslistModule>();

            Bootstrapper.SetAutofacContainer();

            var feed = Bootstrapper.Container.Resolve<IOpportunityFeed>();
            var repository = Bootstrapper.Container.Resolve<IOpportunityRepository>();

            WriteMessage("Fetching New...");

            var result = feed.FetchNew();

            foreach (var opportunity in result)
            {
                opportunity.Resolution = Resolution.New;
                repository.Save(opportunity);
            }

            WriteMessage("All Posts");


            var all = repository.FindAll().ToArray();
            foreach (var opportunity in all)
            {
                System.Console.WriteLine("{0} {1}", opportunity.Title, opportunity.Resolution);
            }

            WriteMessage("Press any key to process posts");
            System.Console.ReadKey();
            System.Console.Clear();
            WriteMessage("Press N to mark post Not Interested.");

            foreach (var opportunity in all.Where(o => o.Resolution == Resolution.New))
            {
                System.Console.WriteLine(opportunity.Title);

                var key = System.Console.ReadKey();
                System.Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.N:
                        opportunity.Resolution = Resolution.NotInterested;
                        repository.Update(opportunity);
                        break;
                    case ConsoleKey.I:
                        opportunity.Resolution = Resolution.Interested;
                        repository.Update(opportunity);
                        break;
                    case ConsoleKey.Spacebar:
                        System.Console.Clear();
                        WriteMessage(opportunity.Title);
                        System.Console.Write(opportunity.Body);
                        System.Console.ReadKey();
                        System.Console.Clear();
                        break;

                }
            }

            System.Console.ReadLine();
        }

        private static void WriteMessage(string message)
        {
            ConsoleColor defaultColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = defaultColor;
        }
    }
}