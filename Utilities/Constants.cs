using AppStoreScarpper.Enums;
using AppStoreScarpper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Utilities
{
   public class Constants
    {
        
        // Specified the Chromium Execution Path
        public static int IgThread;

        public static AppScrapperOptions AppScrapperProcess;

        public static string DappRadarUrl= "https://dappradar.com/";
        public static string MagicStoreUrl= "https://magic.store/";
        public static string ServerAPIUrl= "";
        public static string Server="";
        public static int Port=8080;
        public static string getPostData(MagicStoreAppDetails appDetails)
        {
            var reblogData = new AppDetailsPostData()
            { AppName=appDetails.AppName};
            return JsonConvert.SerializeObject(reblogData);

        }
    }
}
