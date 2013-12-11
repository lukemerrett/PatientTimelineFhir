using Newtonsoft.Json;
using RestClientForFHIR.Model;
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
        private readonly FormatEnum _format;

        public RequestManager(FormatEnum format)
        {
            _format = format;
        }

        public string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["baseURL"];
            }
        }

        public string Format
        {
            get
            {
                return _format == FormatEnum.Json 
                    ? "_format=application/json-fhir" 
                    : "_format=application/xml-fhir";
            }
        }

        /// <summary>
        /// Gets the given resource by it's identifier.
        /// </summary>
        /// <typeparam name="T">The type of resource to get (eg: Patient).</typeparam>
        /// <param name="id">The identifier of the resource to get.</param>
        /// <returns>The matching resource</returns>
        public ResponseResult<T> GetResourceById<T>(int id) where T : IFhirModel
        {
            var resourceName = GetResourceName<T>();

            var targetUrl = string.Format("{0}{1}/@{2}?{3}", BaseUrl, resourceName, id, Format);

            var request = WebRequest.Create(targetUrl);

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseBody = reader.ReadToEnd();

                    var responseObject = JsonConvert.DeserializeObject<T>(responseBody);

                    return new ResponseResult<T>
                    {
                        ResultObject = responseObject,
                        Result = ResultEnum.Success
                    };
                }
            }
        }

        private string GetResourceName<T>() where T : IFhirModel
        {
            return typeof(T).Name.Replace("Model", "");
        }
    }
}
