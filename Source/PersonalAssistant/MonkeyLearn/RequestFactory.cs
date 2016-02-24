using RestSharp;

namespace PersonalAssistant.MonkeyLearn
{
    internal class RequestFactory
    {
        public static RestRequest GetRequest(Method method)
        {
            var request = new RestRequest(method);
            request.AddHeader("Authorization:Token", " 55bdcb2bfdcea0410c10fbbd9aac659bcfa9eb52");
            request.AddHeader("Content-Type:", "application/json");
            request.RequestFormat = DataFormat.Json;
            return request;
        }
    }
}