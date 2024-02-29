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
        public readonly JsonHandler handler = JsonHandler.GetInstance;
        public MagicStoreAppDetailsresponseHandler(IResponseParameter responseParameter):base(responseParameter)
        {
            appDetails=new MagicStoreAppDetails()
            {
                socialLink=new SocialLinks(),
                appReviews=new List<AppReviews> { new AppReviews() { } }
            };
            if (responseParameter == null || string.IsNullOrEmpty(responseParameter.Response)) return;
            try
            {
                Success = true;
                if (!responseParameter.Response.IsValidJson())
                {
                    var decodedResponse = ConstantHelpDetails.GetUtilityBetween(responseParameter.Response, "<script>self.__next_f.push([1,\"26:[\\\"$\\\",\\\"$L15\\\",null,", "]\\n\"])</script>").Replace("\\\"", "\"").Replace("\\\\", "\\");
                    //decodedResponse = "{\"state\":{\"mutations\":" + decodedResponse;
                    handler = new JsonHandler(decodedResponse);
                }
                else
                    handler = new JsonHandler(responseParameter.Response);
                var data = handler.GetJToken( "state","queries",0,"state","data");
                if (!data.HasValues)
                    data= handler.GetJToken("state", "queries", 2, "state", "data");
                 var handler1 = new JsonHandler(data);
                foreach (var token in data)
                    {
                    var appAttributes = handler1.GetJToken("attributes");
                    if(appAttributes.HasValues)
                    {
                        
                            appDetails.AppName = handler1.GetElementValue("attributes", "appName");
                            appDetails.ShortDescription = handler1.GetElementValue("attributes", "shortDescription");
                            appDetails.LongDescription = handler1.GetElementValue("attributes", "longDescription");
                            appDetails.Likes = handler1.GetElementValue("attributes", "likes");
                            appDetails.Link = handler1.GetElementValue("attributes", "link");
                            appDetails.AppRating = handler1.GetElementValue("attributes", "rating");
                            appDetails.Downloads = handler1.GetElementValue("attributes", "downloads");
                            appDetails.AppTitle= handler1.GetElementValue("attributes", "title");
                    }
                    }
                var socialData = handler1.GetJToken("socials");
                foreach (var social in socialData)
                {
                    var SocialHandler=new JsonHandler(social);
                    var socialSite = SocialHandler.GetElementValue("attributes", "linkSite");
                    switch (socialSite.ToLower())
                    {
                        case "discord":
                            appDetails.socialLink.DiscordLink= SocialHandler.GetElementValue("attributes", "link");
                            break;
                        case "facebook":
                            appDetails.socialLink.FacebookLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                        case "linkedin":
                            appDetails.socialLink.LinkedLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                        case "telegram":
                            appDetails.socialLink.TelegramLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                        case "twitter":
                            appDetails.socialLink.TwitterLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                        case "youtube":
                            appDetails.socialLink.YoutubeLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                        case "medium":
                            appDetails.socialLink.MediumLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                          case "twitch":
                            appDetails.socialLink.TwitchLink = SocialHandler.GetElementValue("attributes", "link");
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
            }

        }
        public bool HasMoreResult { get; set; }
        public MagicStoreAppDetails appDetails { get; set; }
    }
}
