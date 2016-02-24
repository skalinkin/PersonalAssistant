using System.Collections.Generic;

namespace PersonalAssistant
{
    public interface ITrainer
    {
        void LoadSamples(Sample [] samples);
        IEnumerable<Categories> GetCategories();
        void Train();
    }
}