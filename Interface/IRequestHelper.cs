using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Interface
{
    public interface IRequestHelper
    {
        void SetRequestParameter(IRequestParameters requestParameters);
        IRequestParameters GetRequestParameter();
    }
}
