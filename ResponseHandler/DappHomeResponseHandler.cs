using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using System.Collections.Generic;

namespace AppStoreScarpper.ResponseHandler
{
    public class DappHomeResponseHandler:ResponseHandler
    {
        public DappHomeResponseHandler(IResponseParameter responseParameter)
        {
            if (responseParameter == null || string.IsNullOrEmpty(responseParameter.Response)) return;

            AppDetailslist = new List<DappRadarAppDetails>();
        }
        public bool HasMoreResult { get; set; }
        public List<DappRadarAppDetails> AppDetailslist { get; set; }
    }
}
