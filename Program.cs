using RestClientForFHIR.Client;
using RestClientForFHIR.Model;
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
            var requestManager = new RequestManager(FormatEnum.Json);

            var responseJson = requestManager.GetResourceById<OrganizationModel>(1); 
        }
    }
}
