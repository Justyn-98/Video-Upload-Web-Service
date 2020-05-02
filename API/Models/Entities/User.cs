using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Videos = new HashSet<Video>();
            PlayLists = new HashSet<PlayList>();
            Comments = new HashSet<Comment>();
            Subscriptions = new HashSet<Subscription>();
            Subscribers = new HashSet<Subscription>();
            Posts = new HashSet<SocialBoardPost>();
            DateOfCreateAccount = DateTime.Now;
        }
        public bool IsActive { get; set; }
        public DateTime DateOfCreateAccount { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; } 
        public ICollection<Subscription> Subscribers { get; set; } 
        public ICollection<Video> Videos { get; set; }
        public ICollection<PlayList> PlayLists { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<SocialBoardPost> Posts { get; set; }

    }
}
