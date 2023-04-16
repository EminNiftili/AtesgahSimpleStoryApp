using Xamarin.Forms;

namespace Atesgah.Models
{
    public class StoryModel
    {
        public int Id { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public string StoryOwnerName { get; set; }
        public bool IsWatched { get; set; }
        public ImageSource CoverPhoto { get; set; }
        public string VideoSourceLink { get; set; }
        public Color WatchColor
        {
            get
            {
                if(!IsWatched)
                {
                    return Color.FromRgb(255, 45, 0); // red color
                }
                else
                {
                    return Color.FromRgb(177, 177, 177); // gray color
                }
            }
        }
    }
}
