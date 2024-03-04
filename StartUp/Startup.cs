using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using AppStoreScarpper.ResponseHandler;
using AppStoreScarpper.Utilities;
using AppStoreScarpper.WebReqHelper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppStoreScarpper.StartUp
{

    public class Startup
    {
        JsonParser parser = JsonParser.GetInstance;
        public List<string> AllSeeAllLinks = new List<string>();
        public List<string> AllAppsLinks = new List<string>();
        public HashSet<string> AllAppsName = new HashSet<string>();
        public List<MagicStoreAppDetails> AllApps = new List<MagicStoreAppDetails>();
        public async Task StartScrapping(string inputType = "")
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
            Console.WriteLine("Scrapper process has been started For MagicStore !!!!");
            var httpHelper = new HttpHelper();
            var requestParamters = httpHelper.GetRequestParameter();
            setHeaderForMagicStore(requestParamters);
            var response = new MagicStoreHomeResponseHandler(httpHelper.GetRequest(url));
            AllSeeAllLinks.AddRange(response.SeeAllLinks);
            response = new MagicStoreHomeResponseHandler(httpHelper.GetRequest(url + "apps/"));
            AllSeeAllLinks.AddRange(response.SeeAllLinks);
            response = new MagicStoreHomeResponseHandler(httpHelper.GetRequest(url + "games/"));
            AllSeeAllLinks.AddRange(response.SeeAllLinks);
            await GetAllDetailsFromLinksForMagicStore(AllSeeAllLinks, httpHelper);
        }
        public async Task startScrappingForDappRadar(string url)
        {
            var httpHelper = new HttpHelper();
            var requestParamters = httpHelper.GetRequestParameter();
            setHeaderForDappRadar(requestParamters);
            var response = new DappHomeResponseHandler(httpHelper.GetRequest(url));
        }
        public async Task GetAllDetailsFromLinksForMagicStore(List<string> links, HttpHelper httpHelper)
        {
            try
            {
                foreach (var link in links)
                {
                    var response = httpHelper.GetRequest(link);
                    var jsonString = ConstantHelpDetails.GetUtilityBetween(response.Response, "<script>self.__next_f.push([1,\"f:[\\\"$\\\",\\\"$L17\\\",null,", "]\\n\"])</script>").Replace("\\\"", "\"").Replace("\\\\", "\\");
                    if (jsonString.IsValidJson())
                    {
                        JObject JsonData = parser.ParseJsonToJObject(jsonString);
                        var Appsdata = parser.GetJTokenValue(JsonData, "state", "queries", 2, "state", "data", "apps");
                        var AppsDetails = parser.GetJArrayElement(Appsdata);
                        foreach (var AppDetail in AppsDetails)
                        {
                            var AppId = parser.GetJTokenValue(AppDetail, "attributes", "appId");
                            if (!string.IsNullOrEmpty(AppId) && !AllAppsLinks.Any(X => X.Contains(AppId)))
                            {
                                AllAppsName.Add(AppId);
                                AllAppsLinks.Add("https://magic.store/app/" + AppId);
                            }
                        }
                    }
                }
                Console.WriteLine($"Total {AllAppsLinks.Count} No of App Links Has Been Found.. !!!!");

                await FinalProcess(AllAppsLinks, httpHelper);
            }
            catch (Exception e)
            {
            }
        }
        public async Task FinalProcess(List<string> Applinks, HttpHelper httpHelper)
        {
            var httpHelper2 = new HttpHelper();
            var requestParamters2 = httpHelper2.GetRequestParameter();
            SetHeadersForServerAPI(requestParamters2);
            foreach (var link in Applinks)
            {
                var response = httpHelper.GetRequest(link);
                var appResponse = new MagicStoreAppDetailsresponseHandler(response);
                if (appResponse.Success && appResponse.appDetails != null)
                {
                    var finalresp = new DatatInsertedResponseHandler(httpHelper2.PostRequest(Constants.ServerAPIUrl, Constants.getPostData(appResponse.appDetails)));
                    if (finalresp.Success)
                        AllApps.Add(appResponse.appDetails);
                }

            }
            Console.WriteLine($"Total {AllApps.Count} No of App Details  Has Inserted SuccessFully.. !!!!");
        }
        public void SetHeadersForServerAPI(IRequestParameters requestParameters)
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
        }
    }
}
