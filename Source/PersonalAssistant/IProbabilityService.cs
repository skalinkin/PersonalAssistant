using PersonalAssistant.Entities;

namespace PersonalAssistant
{
    public interface IProbabilityService
    {
        float AnyliseProbability(Opportunity opportunity);
    }
}