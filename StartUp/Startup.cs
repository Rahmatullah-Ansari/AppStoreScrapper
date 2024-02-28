using AppStoreScarpper.Interface;
using AppStoreScarpper.ResponseHandler;
using AppStoreScarpper.Utilities;
using AppStoreScarpper.WebReqHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.StartUp
{
   public class Startup
    {
        public async Task StartScrapping(string inputType="" )
        {
            if (inputType == Constants.MagicStoreUrl)
                await startScrappingForMagicStore(inputType);
            else
                await startScrappingForDappRadar(inputType);

        }
        public void setHeaderForMagicStore(IRequestParameters requestParameters)
        {
            requestParameters.KeepAlive = true;
            requestParameters.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";
           
            requestParameters.ContentType = "text/html; charset=utf-8";
            ; requestParameters.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";

            requestParameters.Headers["Accept-Language"] = "en-US,en;q=0.9";
            requestParameters.Headers["sec-ch-ua"] = "\"Not.A/Brand\";v=\"8\", \"Chromium\";v=\"114\", \"Google Chrome\";v=\"114\"";
            requestParameters.Headers["Connection"] = "keep-alive";
            requestParameters.Headers["Host"] = "magic.store";
            requestParameters.Headers["sec-ch-ua-mobile"] = "?0";
            requestParameters.Headers["sec-ch-ua-platform"] = "\"windwos\"";
            requestParameters.Headers["Upgrade-Insecure-Requests"] = "1";
            requestParameters.Headers["Sec-Fetch-Site"] = "cross-site";
            requestParameters.Headers["Sec-Fetch-Mode"] = "navigate";
            requestParameters.Headers["Sec-Fetch-User"] = "?1";
            requestParameters.Headers["Sec-Fetch-Dest"] = "document";
            requestParameters.Headers["Sec-Fetch-Site"] = "none";
            requestParameters.Headers["Upgrade-Insecure-Requests"] = "1";
        }
        public void setHeaderForDappRadar(IRequestParameters requestParameters)
        {
            requestParameters.KeepAlive = true;
            requestParameters.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";

            requestParameters.ContentType = "text/html; charset=utf-8";
            ; requestParameters.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";

            requestParameters.Headers["Accept-Language"] = "en-US,en;q=0.9";
            requestParameters.Headers["sec-ch-ua"] = "\"Not.A/Brand\";v=\"8\", \"Chromium\";v=\"114\", \"Google Chrome\";v=\"114\"";
            requestParameters.Headers["Connection"] = "keep-alive";
            requestParameters.Headers["Host"] = "magic.store";
            requestParameters.Headers["sec-ch-ua-mobile"] = "?0";
            requestParameters.Headers["sec-ch-ua-platform"] = "\"windwos\"";
            requestParameters.Headers["Upgrade-Insecure-Requests"] = "1";
            requestParameters.Headers["Sec-Fetch-Site"] = "cross-site";
            requestParameters.Headers["Sec-Fetch-Mode"] = "navigate";
            requestParameters.Headers["Sec-Fetch-User"] = "?1";
            requestParameters.Headers["Sec-Fetch-Dest"] = "document";
            requestParameters.Headers["Sec-Fetch-Site"] = "none";
            requestParameters.Headers["Upgrade-Insecure-Requests"] = "1";

        }
        public async Task startScrappingForMagicStore(string url)
        {
            var httpHelper = new HttpHelper();
            var requestParamters = httpHelper.GetRequestParameter();
            setHeaderForMagicStore(requestParamters);
            var response = new MagicStoreHomeResponseHandler(httpHelper.GetRequest(url));
        }
        public async Task startScrappingForDappRadar(string url)
        {
            var httpHelper = new HttpHelper();
            var requestParamters = httpHelper.GetRequestParameter();
            setHeaderForDappRadar(requestParamters);
            var response = new DappHomeResponseHandler(httpHelper.GetRequest(url));
        }
    }
}
