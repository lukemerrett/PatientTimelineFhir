using RestClientForFHIR.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientTimelineFhir.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITimelineManager _timelineManager;

        public HomeController()
        {
            var baseUrl = ConfigurationManager.AppSettings["Fhir.Api.Base.Url"];
            _timelineManager = new TimelineManager(baseUrl);
        }

        [HttpPost]
        public ActionResult PatientTimeline(string givenName, string familyName)
        {
            var timeline = _timelineManager.GetTimelineForPatient(givenName, familyName);
            return View(timeline);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
