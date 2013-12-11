using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Client;
using Hl7.Fhir.Model;

namespace RestClientForFHIR
{
    public class Program
    {
        public static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["baseURL"];
            }
        }

        public static void Main(string[] args)
        {
            var client = new FhirClient(new Uri(BaseUrl));

            var organisation = client.Read<Organization>("1");
        }
    }
}
