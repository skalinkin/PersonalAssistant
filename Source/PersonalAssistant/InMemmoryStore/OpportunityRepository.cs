using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using PersonalAssistant.Entities;
using PersonalAssistant.InMemmoryStore.POCOs;

namespace PersonalAssistant.InMemmoryStore
{
    internal class OpportunityRepository : IOpportunityRepository
    {
        private MapperConfiguration config;
        private IMapper mapper;

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

        public void Save(Opportunity item)
        {
            var documetn = mapper.Map<OpportunityDocument>(item);

            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();
                collection.Insert(documetn);
                collection.EnsureIndex(d => d.Title);
            }
        }

        public IEnumerable<Opportunity> FindAll()
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

        public Opportunity FindByOriginalSourceId(string link)
        {
            using (var session = new Session())
            {
                var collection = session.GetCollection<OpportunityDocument>();
                var document = collection.FindOne(d => d.OriginalSourceName == "craigslist" && d.OriginalSourceId == link);
                return mapper.Map<Opportunity>(document);
            }
        }
    }
}