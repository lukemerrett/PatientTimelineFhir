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
    public interface IPatientManager
    {
        IEnumerable<Patient> GetAllPatients();

        IEnumerable<Patient> GetPatientsByName(string firstName, string lastName);
    }
}
