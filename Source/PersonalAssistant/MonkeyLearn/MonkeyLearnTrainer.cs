using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace PersonalAssistant.MonkeyLearn
{
    internal class MonkeyLearnTrainer : ITrainer
    {
        public void LoadSamples(Sample[] samples)
        {
            var edpoint = "https://api.monkeylearn.com";
            var client = new RestClient(edpoint);

            var request = new RestRequest("v2/classifiers/cl_ouRyAxT5/samples/", Method.POST);
            request.AddHeader("Authorization", "Token 55bdcb2bfdcea0410c10fbbd9aac659bcfa9eb52");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("sandbox", 1, ParameterType.QueryString);
            request.RequestFormat = DataFormat.Json;

            var requestBody = new UploadSamplesRequest {samples = samples.ToList()};

            request.AddBody(requestBody);

            var response = client.Execute(request);
        }

        public IEnumerable<Categories> GetCategories()
        {
            var edpoint = "https://api.monkeylearn.com";
            var client = new RestClient(edpoint);


            var request = new RestRequest("v2/classifiers/cl_ouRyAxT5/", Method.GET);
            request.AddHeader("Authorization", "Token 55bdcb2bfdcea0410c10fbbd9aac659bcfa9eb52");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("sandbox", 1);
            var response = client.Execute<GetClassifierDetailResponse>(request);
            return response.Data.Result.Categories;
        }

        public void Train()
        {
            var edpoint = "https://api.monkeylearn.com";
            var client = new RestClient(edpoint);

            var request = new RestRequest("v2/classifiers/cl_ouRyAxT5/train/", Method.POST);
            request.AddHeader("Authorization", "Token 55bdcb2bfdcea0410c10fbbd9aac659bcfa9eb52");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("sandbox", 1, ParameterType.QueryString);

            var response = client.Execute(request);
        }
    }
}