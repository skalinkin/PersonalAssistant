using System;
using PersonalAssistant.Entities;

namespace PersonalAssistant.MonkeyLearn
{
    internal class MonkeyLearnService : IProbabilityService
    {
        public float AnyliseProbability(Opportunity opportunity)
        {
            string url = "https://api.monkeylearn.com/v2/classifiers/cl_ouRyAxT5/classify/?sandbox=1";
            System.Net.WebResponse resp = null;
            try
            {
                string jsonString = "{\"text_list\": [\"" + opportunity.Body + "\"]}";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

                System.Net.WebRequest req = System.Net.WebRequest.Create(url);

                //Add these, as we're doing a POST
                req.ContentType = "application/json";
                req.Method = "POST";
                req.Headers.Add("Authorization", Authorization);
                req.ContentLength = bytes.Length;

                System.IO.Stream os = req.GetRequestStream();
                os.Write(bytes, 0, bytes.Length); //Push it out there
                os.Close();
                resp = req.GetResponse();
                if (resp == null)
                    return 0;
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim().Length;
            }
            catch (Exception e)
            {
                if (resp != null)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                    throw new Exception(sr.ReadToEnd().Trim(), e);
                }
                else
                    throw new Exception("URI:" + url + "|Authorization:" + Authorization + "|text:" + opportunity.Body, e);
            }
        }

        public string Authorization { get; set; }
    }
}