using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Tabels
{
    public class VideoOnPlayList
    {
        public string VideoId { get; set; }
        public Video _Video { get; set; }
        public string PlayListId { get; set; }
        public PlayList _PlayList { get; set; }
    }
}
