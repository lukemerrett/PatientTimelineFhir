using Hl7.Fhir.Client;
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
        private readonly IPatientManager _patientManager;

        private readonly ITimelineBuilder _timelineBuilder;

        public TimelineManager(string apiBaseUrl)
        {
            var client = new FhirClient(new Uri(apiBaseUrl));

            _patientManager = new PatientManager(client);
            _timelineBuilder = new TimelineBuilder(client);
        }

        public PatientTimeline GetTimelineForPatient(string givenName, string familyName)
        {
            var patients = _patientManager.GetPatientsByName(givenName, familyName);

            if (!patients.Any())
            {
                throw new Exception("Could not find a matching patient");
            }

            if (patients.Count() > 1)
            {
                throw new Exception("More than one patient found matching this name.");
            }

            var patient = patients.Single();

            var patientIdentifier = patient.Identifier.FirstOrDefault();

            if (patientIdentifier == null)
            {
                throw new Exception("The patient does not have an associated identifier.");
            }

            var timeline = _timelineBuilder.GetTimelineForPatient(patientIdentifier.Key);

            return new PatientTimeline
            {
                PatientGivenName = givenName,
                PatientFamilyName = familyName,
                Timeline = timeline
            };
        }
    }
}
