using System.Collections.Generic;
using PersonalAssistant.Entities;

namespace PersonalAssistant
{
    public interface IOpportunityRepository
    {
        void Save(Opportunity item);
        IEnumerable<Opportunity> FindAll();
        Opportunity FindByOriginalSourceId(string link);
        void Update(Opportunity opportunity);
    }
}