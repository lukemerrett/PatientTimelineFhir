using Hl7.Fhir.Client;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Managers
{
    public class PatientManager : IPatientManager
    {
        private FhirClient _client;

        public PatientManager(FhirClient client)
        {
            _client = client;
        }

        public List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();

            var patientsExist = true;
            var i = 1;

            while (patientsExist)
            {
                try
                {
                    var patient = _client.Read<Patient>(i.ToString());

                    patients.Add(patient.Resource);

                    i++;
                }
                catch (FhirOperationException)
                {
                    patientsExist = false;
                }
            }

            return patients;
        }

        public IEnumerable<Patient> GetPatientsByName(string firstName, string lastName)
        {
            var searchParameters = new[]
                {
                    new SearchParam("Given", firstName),
                    new SearchParam("Family", lastName)
                };

            var matchedPatients = new List<Patient>();

            var result = _client.Search(ResourceType.Patient, searchParameters);

            foreach (var patient in result.Entries)
            {

            }

            return result.Entries.Select(x => (ResourceEntry<Patient>)x).Select(x => x.Resource);
        }
    }
}
