using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ResponseModels
{
    public class CommentResponse
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string Content { get; set; }
    }
}
