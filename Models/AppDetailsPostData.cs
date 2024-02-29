using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Models
{
    public class AppDetailsPostData
    {
        [JsonProperty("userRelation")] public string UserRelation { get; set; }

        [JsonProperty("contactEmail")] public string ContactEmail { get; set; }
        [JsonProperty("logo")] public string Logo { get; set; }
        [JsonProperty("applicationName")] public string AppName { get; set; }

        [JsonProperty("images")] public List<string> Images { get; set; }

        [JsonProperty("vedios")] public List<string> Vedios { get; set; }
        [JsonProperty("gifs")] public List<string> Gifs { get; set; }
        [JsonProperty("tags")] public List<string> Tags { get; set; }
        [JsonProperty("developmentStatus")] public string DevelopementStatus { get; set; }
        [JsonProperty("expectedLaunchDate")] public string ExpectedLunchDate { get; set; }
        [JsonProperty("description")] public Description Description { get; set; }
        [JsonProperty("social")] public List<SocialLinks> SocialLinks { get; set; }

    }
    public class Description
    {
        [JsonProperty("short")] public List<string> ShortDescription { get; set; }
        [JsonProperty("detailed")] public List<string> DetailedDescription { get; set; }
    }

}
