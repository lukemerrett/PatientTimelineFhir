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
    public class PatientManagerTests
    {
        #region Fields

        private IPatientManager _patientManager;

        #endregion

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

        #region SetUp

        [TestInitialize()]
        public void TestSetUp()
        {
            _patientManager = new PatientManager(Client);
        }

        #endregion

        #region Tests

        [TestMethod()]
        public void Ensure_GetAllPatients_returns_a_patient_list()
        {
            var patients = _patientManager.GetAllPatients();

            Assert.IsTrue(patients.Any());
        }

        [TestMethod()]
        public void Ensure_GetPatientsByName_returns_matching_patients()
        {
            var result = _patientManager.GetPatientsByName("Adam", "Everyman");

            Assert.IsTrue(result.Any());
        }

        #endregion
    }
}
