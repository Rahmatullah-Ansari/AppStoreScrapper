using AppStoreScarpper.Interface;
using System.Collections.Generic;

namespace AppStoreScarpper.Models
{
    public class MagicStoreAppDetails:ICommonAppProperty
    {
        public string AppName { get; set; }
        public string AppDescription { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AppIcon { get; set; }
        public string AppRating { get; set; }
        public string Likes{ get; set; }
        public string Downloads { get; set; }
        public string ContactEmails { get; set; }
        public string Link { get; set; }
        public string AppWebSite { get; set; }
        public string GooglePlayLink { get; set; }
        public string DesktopAppLink { get; set; }
        public string AppTitle { get; set; }
        public string AppAuthor { get; set; }
        public string Logo { get; set; }
        public List<string> Vedios { get; set; }
        public List<string> Images { get; set; }
        public List<string> Gifs { get; set; }
        public List<string> Categories { get; set; }
        public List<string> tags { get; set; }
        public SocialLinks socialLink { get; set; }
        public List<AppReviews> appReviews { get; set; }

    }
}
