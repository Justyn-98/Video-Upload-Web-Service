using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities
{
    public class SocialBoardPost
    {
        public SocialBoardPost()
        {
            DateOfCreate = DateTime.Now;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Likes { get; set; }
        public string Photo { get; set; } 
        public DateTime DateOfCreate { get; set; }
        public string Content { get; set; }
    }
}
