namespace API.Models.Entities
{
    public class VideoOnPlayList
    {
        public string VideoId { get; set; }
        public Video Video { get; set; }
        public string PlayListId { get; set; }
        public PlayList PlayList { get; set; }
    }
}
