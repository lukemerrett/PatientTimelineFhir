using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Dtos
{
    public class PatientTimeline
    {
        public string PatientGivenName { get; set; }

        public string PatientFamilyName { get; set; }

        public IEnumerable<TimelineEntry> Timeline { get; set; }
    }
}
