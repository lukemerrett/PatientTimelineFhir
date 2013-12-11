using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Model.Children
{
    public class Telecom
    {
        public ValueContainer System { get; set; }

        public ValueContainer Value { get; set; }

        public ValueContainer Use { get; set; }
    }
}
