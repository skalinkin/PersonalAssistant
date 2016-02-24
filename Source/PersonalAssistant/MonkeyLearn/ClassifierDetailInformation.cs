using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace PersonalAssistant.MonkeyLearn
{
    internal class ClassifierDetailInformation
    {
        public Classifier Classifier { get; set; }

        [SerializeAs(Name = "sandbox_categories")]
        [DeserializeAs(Name = "sandbox_categories")]
        public List<Categories> Categories { get; set; }
    }
}