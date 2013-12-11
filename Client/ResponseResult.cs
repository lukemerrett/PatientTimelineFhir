using RestClientForFHIR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientForFHIR.Client
{
    public class ResponseResult<T> where T : IFhirModel
    {
        public T ResultObject { get; set; }

        public ResultEnum Result { get; set; }
    }
}
