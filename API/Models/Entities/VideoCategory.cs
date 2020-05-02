using System.Collections.Generic;

namespace API.Models.Entities
{
    public class VideoCategory
    {
        public VideoCategory()
        {
            Videos = new HashSet<Video>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
