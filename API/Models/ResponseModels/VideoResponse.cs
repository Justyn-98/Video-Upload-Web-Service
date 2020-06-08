using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ResponseModels
{
    public class VideoResponse
    {
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public string UrlAddress { get; set; }
        public string PhotoUrl { get; set; }
    }
}
