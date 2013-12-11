using RestClientForFHIR.Model.Children;
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
        public Text Text { get; set; }

        public List<Identifier> Identifier { get; set; }

        public ValueContainer Name { get; set; }

        public List<Telecom> Telecom { get; set; }

        public PartOf PartOf { get; set; }
    }
}
