using RestClientForFHIR.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientTimelineFhir.UI.Controllers
{
    public class HomeController : Controller
    {
        private IPatientManager _patientManager;

        private ITimelineManager _timelineManager;

        public HomeController(IPatientManager patientManager, ITimelineManager timelineManager)
        {
            _patientManager = patientManager;
            _timelineManager = timelineManager;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
