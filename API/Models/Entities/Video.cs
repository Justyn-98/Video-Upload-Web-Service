using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace API.Models.Entities
{
    public class Video
    {
        public Video()
        {
            Comments = new HashSet<Comment>();
            VideoOnPlayLists = new HashSet<VideoOnPlayList>();
            DateOfCreate = DateTime.Now;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string VideoCategoryId { get; set; }
        public VideoCategory VideoCategory { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string UrlAddress { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
        public int Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<VideoOnPlayList> VideoOnPlayLists { get; set; }
    }
}
