using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Tabels
{
    public class Video
    {
        [Key]
        public string Id { get; set; }
        public User _User { get; set; }
        public string Name { get; set; }
        public string UrlAdress { get; set; }
        public string Description { get; set; }
        public VideoCategory _VideoCategory { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<VideoOnPlayList> VideoOnPlayLists { get; set; }
    }
}
