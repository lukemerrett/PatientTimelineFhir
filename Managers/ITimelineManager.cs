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
        PatientTimeline GetTimelineForPatient(string givenName, string familyName);
    }
}
