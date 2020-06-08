using System.ComponentModel.DataAnnotations;

namespace API.Models.RequestModels
{
    public class VideoRequest
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
