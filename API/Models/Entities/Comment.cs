using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Tabels
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public string Content { get; set; }
        public User _User { get; set; }
        public Video _Video { get; set; }
    }
}
