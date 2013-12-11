using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Model
{
    public class OrganizationModel : IFhirModel
    {
        public Organization Organization { get; set; }
    }

    public class Organization
    {
        public object Text { get; set; }

        public object Identifier { get; set; }

        public object Name { get; set; }

        public object Telecom { get; set; }

        public object PartOf { get; set; }
    }
}
