using AppStoreScarpper.Interface;

namespace AppStoreScarpper.Models
{
    public class DappRadarAppDetails : ICommonAppProperty
    {
        public string AppName { get; set ; }
        public string AppDescription { get ; set ; }
        public string AppIcon { get; set; }
        public string AppRating { get; set; }
        public string AppTitle { get; set; }
        public string AppAuthor { get; set; }
    }
}
