using System;
using System.Linq;
using Autofac;
using CommandLine;
using Console.Commands;
using Console.Options;
using PersonalAssistant;
using PersonalAssistant.Craigslist;
using PersonalAssistant.Entities;
using PersonalAssistant.InMemmoryStore;
using PersonalAssistant.MonkeyLearn;

namespace Console
{
    internal class Program
    {
        private const string ReadPrompt = "PA> ";

        private static void Main(string[] args)
        {
            Bootstrapper.InitializeBuilder();
            Bootstrapper.Builder.RegisterModule<InMemmoryStoreModule>();
            Bootstrapper.Builder.RegisterModule<CraigslistModule>();
            Bootstrapper.Builder.RegisterModule<MonkeyLearnModule>();
            Bootstrapper.SetAutofacContainer();

            var verb = Parser.Default.ParseArguments<DiscoverOptions, TitleAnalisysOptions, DropDbOptions>(args);

            var command = GetCommand(verb as Parsed<object>);

            command.Execute();
        }

        private static Command GetCommand(Parsed<object> verb)
        {
            if (verb == null)
            {
                return new DefaultCommand();
            }

            if (verb.Value.GetType() == typeof (DiscoverOptions))
            {
                return new DiscoverCommand();
            }

            if (verb.Value.GetType() == typeof (TitleAnalisysOptions))
            {
                return new TitleAnalisysCommand();
            }

            if (verb.Value.GetType() == typeof(DropDbOptions))
            {
                return new DropDbCommand();
            }

            return new DefaultCommand();
        }

        public static string ReadFromConsole(string promptMessage = "")
        {
            System.Console.Write(ReadPrompt + promptMessage);
            return System.Console.ReadLine();
        }

        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                System.Console.WriteLine(message);
            }
        }

        private static void Analisys()
        {
            var repository = Bootstrapper.Container.Resolve<OpportunityRepository>();

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
        }

        private static void WriteMessage(string message)
        {
            var defaultColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = defaultColor;
        }
    }
}