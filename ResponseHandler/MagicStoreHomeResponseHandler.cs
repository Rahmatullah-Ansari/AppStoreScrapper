using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using AppStoreScarpper.Utilities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AppStoreScarpper.ResponseHandler
{
    public class MagicStoreHomeResponseHandler : ResponseHandler
    {
        public List<string> SeeAllLinks = new List<string>();
        public MagicStoreHomeResponseHandler(IResponseParameter responseParameter)
        {
            if (responseParameter == null || string.IsNullOrEmpty(responseParameter.Response)) return;
            var jsonString = "";
            try
            {
                AppDetails = new List<MagicStoreAppDetails>();
                Response = responseParameter;
                Success = true;
                if (responseParameter.Response.Contains("https://magic.store/apps") || responseParameter.Response.Contains("https://magic.store/games") || responseParameter.Response.Contains("https://magic.store/upcoming"))
                    jsonString = ConstantHelpDetails.GetUtilityBetween(responseParameter.Response, "<script>self.__next_f.push([1,\"7:[\\\"$\\\",\\\"$L15\\\",null,", "]\\n\"])</script>").Replace("\\\"", "\"").Replace("\\\\", "\\");
                else
                    jsonString = ConstantHelpDetails.GetUtilityBetween(responseParameter.Response, "<script>self.__next_f.push([1,\"b:[\\\"$\\\",\\\"$L13\\\",null,", "]\\n\"])</script>").Replace("\\\"", "\"").Replace("\\\\", "\\");
                try
                {
                    JObject JsonData = parser.ParseJsonToJObject(jsonString);
                    var Data = parser.GetJTokenValue(JsonData, "state", "queries", 2, "state", "data", "rows");
                    if (string.IsNullOrEmpty(Data))
                        Data = parser.GetJTokenValue(JsonData, "state", "queries", 0, "state", "data", "rows");
                    var rows = parser.GetJArrayElement(Data);
                    foreach (var row in rows)
                    {
                        var link = parser.GetJTokenValue(row, "blocks", 0, "attributes", "link");
                        if (string.IsNullOrEmpty(link))
                            link = parser.GetJTokenValue(row, "blocks", 1, "attributes", "link");
                        if (responseParameter.Response.Contains("https://magic.store/apps") && !responseParameter.Response.Contains("https://magic.store/games") && !link.Contains("stories") && !string.IsNullOrEmpty(link) && !link.StartsWith("http"))
                            SeeAllLinks.Add("https://magic.store/apps/" + link);
                        else if (!responseParameter.Response.Contains("https://magic.store/apps") && responseParameter.Response.Contains("https://magic.store/games") && !link.Contains("stories") && !string.IsNullOrEmpty(link) && !link.StartsWith("http"))
                            SeeAllLinks.Add("https://magic.store/games/" + link);
                        else if (!link.Contains("stories") && !string.IsNullOrEmpty(link) && !link.StartsWith("http"))
                            SeeAllLinks.Add("https://magic.store/discover/" + link);
                    }
                }
                catch (System.Exception e)
                {
                }
            }
            catch (System.Exception e) { }
        }
        public bool HasMoreResult { get; set; }
        public List<MagicStoreAppDetails> AppDetails { get; set; }
    }
}
