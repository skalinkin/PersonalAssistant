using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace PersonalAssistant.MonkeyLearn
{
    internal class Classifier
    {
        [SerializeAs(Name = "hashed_id")]
        [DeserializeAs(Name = "hashed_id")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}