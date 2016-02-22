using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using PersonalAssistant.Entities;
using PersonalAssistant.InMemmoryStore.POCOs;

namespace PersonalAssistant.InMemmoryStore
{
    internal class OpportunityRepository : PersonalAssistant.OpportunityRepository
    {
        private MapperConfiguration config;
        private readonly IMapper mapper;

        public OpportunityRepository()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Opportunity, OpportunityDocument>();
                cfg.CreateMap<OpportunityDocument, Opportunity>();
            });
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();
        }

        public override string SourceName => "craigslist";

        public override void Save(Opportunity item)
        {
            var documetn = mapper.Map<OpportunityDocument>(item);

            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();
                collection.Insert(documetn);
                collection.EnsureIndex(d => d.Title);
            }
        }

        public override IEnumerable<Opportunity> FindAll()
        {
            var result = new Collection<Opportunity>();

            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();
                foreach (var document in collection.FindAll())
                {
                    result.Add(mapper.Map<Opportunity>(document));
                }
            }
            return result;
        }

        public override Opportunity FindByOriginalSourceId(string link)
        {
            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();
                var document = collection.FindOne(d => d.OriginalSourceName == SourceName && d.OriginalSourceId == link);
                return mapper.Map<Opportunity>(document);
            }
        }

        public override bool ExistsWithOriginalSourceId(string link)
        {
            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();
                var exists = collection.Count(d => d.OriginalSourceName == SourceName && d.OriginalSourceId == link) > 0;
                return exists;
            }
        }

        public override void Update(Opportunity opportunity)
        {
            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();

                var document = collection.FindOne(d => d.Id == opportunity.Id);
                mapper.Map(opportunity, document);
                collection.Update(document);

            }
        }
    }
}