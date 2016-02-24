using System.Collections.Generic;

namespace PersonalAssistant
{
    public interface ITrainer
    {
        void Train(Sample [] samples);
        IEnumerable<Categories> GetCategories();
    }
}