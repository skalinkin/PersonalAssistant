using System.Collections.Generic;
using PersonalAssistant.Entities;

namespace PersonalAssistant
{
    public abstract class OpportunityRepository
    {
        public abstract string SourceName { get; }
        public abstract void Save(Opportunity item);
        public abstract IEnumerable<Opportunity> FindAll();
        public abstract Opportunity FindByOriginalSourceId(string link);
        public abstract void Update(Opportunity opportunity);
        public abstract bool ExistsWithOriginalSourceId(string link);
    }
}