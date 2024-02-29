using AppStoreScarpper.Interface;
using AppStoreScarpper.Models;
using AppStoreScarpper.Utilities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AppStoreScarpper.ResponseHandler
{
    public class MagicStoreHomeResponseHandler:ResponseHandler
    {
        public List<string> SeeAllLinks = new List<string>();
        public readonly JsonParser parser = JsonParser.GetInstance;
        public MagicStoreHomeResponseHandler(IResponseParameter responseParameter)
        {
            if (responseParameter == null|| string.IsNullOrEmpty(responseParameter.Response)) return;
            try
            {
                AppDetails = new List<MagicStoreAppDetails>();
                Response = responseParameter;
                Success = true;
                var jsonString = ConstantHelpDetails.GetUtilityBetween(responseParameter.Response, "<script>self.__next_f.push([1,\"b:[\\\"$\\\",\\\"$L13\\\",null,", "]\\n\"])</script>");
                try
                {
                    JObject JsonData = parser.ParseJsonToJObject(jsonString.Replace("\\\"", "\"").Replace("\\\\", "\\"));
                    var Data = parser.GetJTokenValue(JsonData, "state", "queries", 2, "state", "data", "rows");
                    var rows = parser.GetJArrayElement(Data);
                    foreach (var row in rows)
                    {
                        var link = parser.GetJTokenValue(row, "blocks", 0, "attributes", "link");
                        if (!link.Contains("stories") && !string.IsNullOrEmpty(link) && !link.StartsWith("http"))
                            SeeAllLinks.Add("https://magic.store/discover/" + link);
                    }
                }
                catch (System.Exception e)
                {
                }
            }catch(System.Exception e) { }
        }
        public bool HasMoreResult {  get; set; }
        public List<MagicStoreAppDetails> AppDetails { get; set; }
    }
}
