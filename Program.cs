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
        #region Properties

        private static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["baseURL"];
            }
        }

        #endregion

        #region Public Methods

        public static void Main(string[] args)
        {
            var client = new FhirClient(new Uri(BaseUrl));

            var patient = client.Read<Patient>("1");

            var patientProvider = patient.Resource.Provider;

            if (patientProvider.Type == typeof(Organization).Name)
            {
                var id = ExtractIdFromReference(patientProvider);

                var patientOrganiszation = client.Read<Organization>(id);

                var patientName = patient.Resource.Name.First();

                Console.WriteLine(
                    string.Format("Patient: {0} {1} - Provided By {1}\n", 
                    string.Join(" ", patientName.Given),
                    string.Join(" ", patientName.Family),
                    patientOrganiszation.Resource.Name));

                Console.WriteLine(string.Format("Narrative:\n\n{0}", patient.Resource.Text.Div));
            }            

            Console.ReadLine();
        }

        #endregion

        #region Methods

        private static string ExtractIdFromReference(ResourceReference resourceReference)
        {
            var atPosition = resourceReference.Reference.IndexOf('@');

            return resourceReference.Reference.Substring(atPosition + 1);
        }

        #endregion
    }
}
