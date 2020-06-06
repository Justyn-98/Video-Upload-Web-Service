using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ApiModels
{
    public class CommentModel
    {
        [Required]
        public string Content { get; set; }
    }
}
