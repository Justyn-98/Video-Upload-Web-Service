using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Tabels
{
    public class PlayList
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public User _User { get; set; }
        public ICollection<VideoOnPlayList> VideosOnPlayList { get; set; }
    }
}
