using Hl7.Fhir.Client;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support.Search;
using RestClientForFHIR.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Managers
{
    public interface ITimelineManager
    {
        IEnumerable<TimelineEntry> GetTimelineForPatient(string patientIdentifier);
    }
}
