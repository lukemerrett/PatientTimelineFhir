using RestClientForFHIR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR
{
    public class Program
    {
        static void Main(string[] args)
        {
            var requestManager = new RequestManager();

            dynamic responseJson = requestManager.SendSampleGetRequest(); 
        }
    }
}
