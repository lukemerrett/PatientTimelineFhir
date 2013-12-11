using Hl7.Fhir.Client;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Managers
{
    public class PatientManager
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
                catch (FhirOperationException ex)
                {
                    patientsExist = false;
                }
            }

            return patients;
        }
    }
}
