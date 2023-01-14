using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoApp
{
    public class API
    {

        public List<string> demo_api()
        {
            string url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo";
            var client = new RestClient(url);
            var request = new RestRequest();
            var content = client.ExecuteGet(request);
            string jsonContent = content.Content!;
            dynamic? result = JsonConvert.DeserializeObject<dynamic>(jsonContent);
            var data = new List<string>();
           foreach(var obj in result["Global Quote"])
            {
                data.Add(obj.Name + ": " + obj.Value);
            }
            return data;
        }
    }
}
