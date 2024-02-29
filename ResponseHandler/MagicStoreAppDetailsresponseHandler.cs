using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using AppStoreScarpper.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppStoreScarpper.ResponseHandler
{
    public  class MagicStoreAppDetailsresponseHandler: ResponseHandler
    {
        public MagicStoreAppDetailsresponseHandler(IResponseParameter responseParameter):base(responseParameter)
        {

            if (responseParameter == null || string.IsNullOrEmpty(responseParameter.Response)) return;
            try
            {
                Success = true;
                JsonHandler handler = null;
                if (!responseParameter.Response.IsValidJson())
                {
                    var decodedResponse = ConstantHelpDetails.GetUtilityBetween(responseParameter.Response, "{\"state\":{\"mutations\":", "]");
                    decodedResponse = "{\"state\":{\"mutations\":" + decodedResponse;
                    handler = new JsonHandler(decodedResponse);
                }
                else
                {
                    handler = new JsonHandler(responseParameter.Response);
                }
                
                var data = handler.GetJToken("state","queries",0,"state","data");
                if (data.HasValues)
                {
                  var  handler1=new JsonHandler(data);
                    foreach (var token in data)
                    {
                        appDetails.AppName = handler.GetElementValue("aapName");
                        appDetails.ShortDescription = handler.GetElementValue("shortDescription");
                        appDetails.LongDescription = handler.GetElementValue("longDescription");
                        appDetails.Likes = handler.GetElementValue("likes");
                        appDetails.Link = handler.GetElementValue("link");
                        appDetails.AppRating = handler.GetElementValue("rating");
                        appDetails.Downloads = handler.GetElementValue("downloads");

                    }

                }
            }
            catch (Exception ex)
            {
            }
            appDetails = new MagicStoreAppDetails();

        }
        public bool HasMoreResult { get; set; }
        public MagicStoreAppDetails appDetails { get; set; }
    }
}
