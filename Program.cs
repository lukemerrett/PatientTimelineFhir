using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Client;
using Hl7.Fhir.Model;
using RestClientForFHIR.Managers;

namespace RestClientForFHIR
{
    public class Program
    {
        #region Properties

        private static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["baseURL"];
            }
        }

        private static FhirClient Client
        {
            get
            {
                return new FhirClient(new Uri(BaseUrl));
            }
        }

        #endregion

        #region Public Methods

        public static void Main(string[] args)
        {
            var patientManager = new PatientManager(Client);

            var patients = patientManager.GetAllPatients();
        }

        #endregion
    }
}
