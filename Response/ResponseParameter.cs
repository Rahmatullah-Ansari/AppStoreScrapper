using AppStoreScarpper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Response
{
    public class ResponseParameter:IResponseParameter
    {
        public bool HasError { get; set; }
        public string Response { get; set; }
        public Exception Exception { get; set; }

    }
}
