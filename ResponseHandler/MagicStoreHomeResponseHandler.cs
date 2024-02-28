using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using System.Collections.Generic;

namespace AppStoreScarpper.ResponseHandler
{
    public class MagicStoreHomeResponseHandler:ResponseHandler
    {
        public MagicStoreHomeResponseHandler(IResponseParameter responseParameter)
        {
            if (responseParameter == null|| string.IsNullOrEmpty(responseParameter.Response)) return;

            AppDetails = new List<MagicStoreAppDetails>();
        }
        public bool HasMoreResult {  get; set; }
        public List<MagicStoreAppDetails> AppDetails { get; set; }
    }
}
