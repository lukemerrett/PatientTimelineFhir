using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Dtos
{
    public class TimelineEntry
    {
        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public TimelineEntryType TypeOfEntry { get; set; }

        public string Summary { get; set; }
    }
}
