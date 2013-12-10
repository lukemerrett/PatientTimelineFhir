using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Client
{
    public class RequestManager
    {
        public string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["baseURL"];
            }
        }

        public object SendSampleGetRequest()
        {
            var targetUrl = string.Format("{0}{1}?{2}", BaseUrl, "metadata", "_format=application/json-fhir");

            var request = WebRequest.Create(targetUrl);

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseBody = reader.ReadToEnd();

                    return JsonConvert.DeserializeObject(responseBody);
                }
            }
        }
    }
}
