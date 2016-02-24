using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace PersonalAssistant
{
    public class Sample
    {
        [SerializeAs(Name = "text")]
        [DeserializeAs(Name = "text")]
        public string text { get; set; }

        [SerializeAs(Name = "category_id")]
        [DeserializeAs(Name = "category_id")]
        public int category_id { get; set; }
    }
}