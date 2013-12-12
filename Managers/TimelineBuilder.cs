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
    internal class TimelineBuilder : ITimelineBuilder
    {
        private FhirClient _client;

        public TimelineBuilder(FhirClient client)
        {
            _client = client;
        }

        public IEnumerable<TimelineEntry> GetTimelineForPatient(string patientIdentifier)
        {
            var timeline = new List<TimelineEntry>();

            var matchingEncounters = _client.Search(ResourceType.Encounter, "subject.identifier", patientIdentifier);
            var matchingAlerts = _client.Search(ResourceType.Alert, "subject.identifier", patientIdentifier);

            ProcessAlerts(timeline, matchingAlerts);
            ProcessEncounters(timeline, matchingEncounters);

            return timeline.OrderBy(x => x.StartTime).ThenBy(x => x.EndTime);
        }

        private static void ProcessAlerts(List<TimelineEntry> timeline, Bundle matchingAlerts)
        {
            foreach (var encounter in matchingAlerts.Entries.Select(x => (ResourceEntry<Alert>)x))
            {
                var startTime = encounter.Published;
                var endTime = encounter.Published;

                timeline.Add(new TimelineEntry
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    TypeOfEntry = TimelineEntryType.Alert,
                    Summary = encounter.Resource.Note
                });
            }
        }

        private static void ProcessEncounters(List<TimelineEntry> timeline, Bundle matchingEncounters)
        {
            foreach (var encounter in matchingEncounters.Entries.Select(x => (ResourceEntry<Encounter>)x))
            {
                DateTimeOffset? startTime;
                DateTimeOffset? endTime;

                if (encounter.Resource.Hospitalization != null)
                {
                    startTime = DateTimeOffset.Parse(encounter.Resource.Hospitalization.Period.Start);
                    endTime = DateTimeOffset.Parse(encounter.Resource.Hospitalization.Period.End);
                }
                else
                {
                    startTime = encounter.Published;
                    endTime = encounter.Published;
                }

                timeline.Add(new TimelineEntry
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    TypeOfEntry = TimelineEntryType.Encounter,
                    Summary = encounter.Resource.Reason.ToString()
                });
            }
        }

        private string GetIdentifierFromUri(Uri id)
        {
            return id.Segments.Last().Replace("@", "");
        }
    }
}
