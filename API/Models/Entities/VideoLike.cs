using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    public class VideoLike
    {
        public string Id { get; set; }
        public string VideoId { get; set; }
        public Video Video { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
