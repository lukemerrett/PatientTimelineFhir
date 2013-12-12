using Hl7.Fhir.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestClientForFHIR.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientTimelineFhir.IntegrationTests
{
    [TestClass()]
    public class TimelineBuilderTests
    {
        #region Fields

        private IPatientManager _patientManager;

        private ITimelineBuilder _timelineBuilder;

        #endregion

        #region Properties

        private static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["baseURL"];
            }
        }

        #endregion

        #region SetUp

        [TestInitialize()]
        public void TestSetUp()
        {
            var client = new FhirClient(new Uri(BaseUrl));
            _timelineBuilder = new TimelineBuilder(client);
            _patientManager = new PatientManager(client);
        }

        #endregion

        #region Tests

        [TestMethod()]
        public void Ensure_GetTimelineForPatient_returns_a_timeline_for_patient()
        {
            var patients = _patientManager.GetPatientsByName("Roelof Olaf", "Bor");

            var patient = patients.FirstOrDefault();

            if (patient == null)
            {
                Assert.Fail("Could not find a patient to get the timeline for.");
            }

            var patientIdentifier = patient.Identifier.FirstOrDefault();

            if (patientIdentifier == null)
            {
                Assert.Fail("The patient does not have an associated identifier.");
            }

            var timeline = _timelineBuilder.GetTimelineForPatient(patientIdentifier.Key);

            Assert.IsNotNull(timeline);
        }

        #endregion
    }
}
