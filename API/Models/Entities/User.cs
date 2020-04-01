using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Tabels
{
    public class User : IdentityUser
    {
        public ICollection<Video> Videos { get; set; }
        public ICollection<PlayList> PlayLists { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
