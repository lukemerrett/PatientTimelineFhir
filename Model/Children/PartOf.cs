using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Model.Children
{
    public class PartOf
    {
        public ValueContainer Type { get; set; }

        public ValueContainer Reference { get; set; }

        public ValueContainer Display { get; set; }
    }
}
