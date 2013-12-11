using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Model.Children
{
    public class Identifier
    {
        public ValueContainer System { get; set; }

        public ValueContainer Key { get; set; }
    }
}
