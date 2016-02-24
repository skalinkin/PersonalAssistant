using System.Collections.ObjectModel;
using System.Linq;
using Console.Options;
using PersonalAssistant;
using PersonalAssistant.Entities;

namespace Console.Commands
{
    internal class TrainCommand : Command
    {
        private readonly ITrainer trainer;
        private readonly OpportunityRepository repository;

        public TrainCommand(ITrainer trainer, OpportunityRepository repository)
        {
            this.trainer = trainer;
            this.repository = repository;
        }

        public override void Execute(object opt)
        {
            var options = (TrainOptions)opt;

            if (options.ListCategories)
            {
                foreach (var category in trainer.GetCategories())
                {
                    System.Console.WriteLine("{0,10}{1,20}", category.Id, category.Name);
                }
                return;
            }


            var samples = new Collection<Sample>();
            var categories = trainer.GetCategories();
            var intrestedCategory = categories.First(c => c.Name == "Interested").Id;
            var notInterestedCategory = categories.First(c => c.Name == "Not Interested").Id;

            foreach (var opportunity in repository.FindAll().Where(o => !o.Trained && o.Resolution != Resolution.New))
            {
                var sample = new Sample();

                sample.text = opportunity.Body;
                sample.category_id = opportunity.Resolution == Resolution.Interested ? intrestedCategory : notInterestedCategory;
                samples.Add(sample);
            }

            trainer.Train(samples.ToArray());
        }
    }
}