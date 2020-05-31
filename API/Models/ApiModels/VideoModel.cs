using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ApiModels
{
    public class VideoModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string VideoPath { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string VideoCategoryId { get; set; }

    }
}
