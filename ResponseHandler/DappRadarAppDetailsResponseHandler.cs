using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.ResponseHandler
{
    public class DappRadarAppDetailsResponseHandler
    {
        public List<DappRadarAppDetails> appList { get; set; }
        public DappRadarAppDetailsResponseHandler(IResponseParameter responseParameter)
        {
            if (responseParameter == null || string.IsNullOrEmpty(responseParameter.Response)) return;
        }
    }
}
