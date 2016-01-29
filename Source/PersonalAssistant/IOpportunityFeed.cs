using System.Collections.Generic;
using PersonalAssistant.Entities;

namespace PersonalAssistant
{
    public interface IOpportunityFeed
    {
        IEnumerable<Opportunity> FetchNew();
    }
}