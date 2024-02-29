using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Models
{
   public  class SocialLinks
    {
        [JsonProperty("facebook")] public string FacebookLink { get; set; } = "";
        [JsonProperty("twitter")] public string TwitterLink { get; set; } = "";
        [JsonProperty("reddit")] public string RedditLink { get; set; } = "";
        [JsonProperty("telegram")] public string TelegramLink { get; set; } = "";
        [JsonProperty("github")] public string DiscordLink { get; set; } = "";
        [JsonProperty("medium")] public string MediumLink { get; set; } = "";
         [JsonProperty("discord")] public string GithubLink { get; set; } = "";
        [JsonProperty("instagram")] public string InstagramLink { get; set; } = "";
        [JsonProperty("youtube")] public string YoutubeLink { get; set; } = "";
        [JsonProperty("slack")] public string Link { get; set; } = "";
        [JsonProperty("linkedIn")] public string LinkedLink { get; set; } = "";
        [JsonProperty("twitch")] public string TwitchLink { get; set; } = "";
    }
}
