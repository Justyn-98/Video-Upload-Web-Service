using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ApiModels
{
    public class VideoModel
    {
        public string Name { get; set; }
        public string VideoPath { get; set; }
        public string Description { get; set; }
        public string VideoCategoryId { get; set; }

    }
}
