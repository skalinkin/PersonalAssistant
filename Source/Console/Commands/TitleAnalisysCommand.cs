using System;
using System.Linq;
using Autofac;
using PersonalAssistant;
using PersonalAssistant.Entities;

namespace Console.Commands
{
    internal class TitleAnalisysCommand : Command
    {
        public override void Execute(object opt)
        {
            var repository = Bootstrapper.Container.Resolve<OpportunityRepository>();

            var all = repository.FindAll().ToArray();
            foreach (var opportunity in all)
            {
                System.Console.WriteLine("{0} {1}", opportunity.Title, opportunity.Resolution);
            }

            System.Console.ReadKey();
            System.Console.Clear();

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
                        System.Console.Write(opportunity.Body);
                        System.Console.ReadKey();
                        System.Console.Clear();
                        break;
                }
            }
        }
    }
}