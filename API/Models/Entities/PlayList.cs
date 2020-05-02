using System.Collections.Generic;

namespace API.Models.Entities
{
    public class PlayList
    {
        public PlayList()
        {
            VideosOnPlayList = new HashSet<VideoOnPlayList>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<VideoOnPlayList> VideosOnPlayList { get; set; }
    }
}
