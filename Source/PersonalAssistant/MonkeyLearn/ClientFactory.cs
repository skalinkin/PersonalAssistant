using RestSharp;

namespace PersonalAssistant.MonkeyLearn
{
    internal class ClientFactory
    {
        private static string rootUrl = "";

        public static RestClient GetClientForClassifiersSamples()
        {
            var edpoint = "https://api.monkeylearn.com/v2/classifiers/cl_ouRyAxT5/samples/";
            var client = GetClient(edpoint);
            return client;
        }

        public static RestClient GetClient(string url)
        {
            var client = new RestClient(url);
            return client;
        }
    }
}