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
    public class TimelineManager : ITimelineManager
    {
        private FhirClient _client;

        public TimelineManager(FhirClient client)
        {
            _client = client;
        }

        public IEnumerable<TimelineEntry> GetTimelineForPatient(Uri patientId)
        {
            var id = GetIdentifierFromUri(patientId);

            throw new NotImplementedException("In progress");
        }

        private string GetIdentifierFromUri(Uri id)
        {
            return id.Segments.Last().Replace("@", "");
        }
    }
}
