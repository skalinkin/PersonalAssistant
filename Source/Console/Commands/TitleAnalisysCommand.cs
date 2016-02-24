using System;
using System.Linq;
using PersonalAssistant;
using PersonalAssistant.Entities;

namespace Console.Commands
{
    internal class TitleAnalisysCommand : Command
    {
        private readonly OpportunityRepository repository;

        public TitleAnalisysCommand(OpportunityRepository repository)
        {
            this.repository = repository;
        }

        public override void Execute(object opt)
        {
            foreach (var opportunity in repository.FindAll().Where(o => o.Resolution == Resolution.New))
            {
                System.Console.Clear();
                var defaultColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("I - Interested, N - NotInterested, spacebar - see body.");
                System.Console.ForegroundColor = defaultColor;
                System.Console.WriteLine(opportunity.Title);

                var key = System.Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.N:
                        opportunity.Resolution = Resolution.NotInterested;
                        repository.Update(opportunity);
                        continue;
                    case ConsoleKey.I:
                        opportunity.Resolution = Resolution.Interested;
                        repository.Update(opportunity);
                        continue;
                    case ConsoleKey.Spacebar:
                        System.Console.Clear();
                        System.Console.Write(opportunity.Body);
                        System.Console.ReadKey();
                        System.Console.Clear();
                        break;
                }
            }
        }
    }
}