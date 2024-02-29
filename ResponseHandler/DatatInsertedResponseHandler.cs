using AppStoreScarpper.Interface;
using AppStoreScarpper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.ResponseHandler
{
    public class DatatInsertedResponseHandler : ResponseHandler
    {
        public DatatInsertedResponseHandler(IResponseParameter responseParameter)
        {
            if (responseParameter == null || string.IsNullOrEmpty(responseParameter.Response)) return;
            try
            {
                if(responseParameter.Response.Contains("{\"meta\":{\"status\":200,\"msg\":\"OK\"}")) Success = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
