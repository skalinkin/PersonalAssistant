using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace PersonalAssistant.MonkeyLearn
{
    internal class UploadSamplesRequest
    {
        [SerializeAs(Name = "samples")]
        [DeserializeAs(Name = "samples")]
        public List<Sample> samples { get; set; }
    }
}