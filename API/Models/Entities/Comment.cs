using System;

namespace API.Models.Entities
{
    public class Comment
    {
        public Comment()
        {
            DateOfCreate = DateTime.Now;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string VideoId { get; set; }
        public Video Video { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string Content { get; set; }

    }
}
