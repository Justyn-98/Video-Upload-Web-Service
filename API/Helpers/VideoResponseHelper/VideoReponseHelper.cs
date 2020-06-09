using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.VideoResponseHelper
{
    public class VideoReponseHelper : IVideoResponseHelper
    {
        public List<VideoResponse> PrepareVideosToSend(List<Video> videos)
        {
            var videosToSend = new List<VideoResponse>();
            foreach (var video in videos)
            {
                videosToSend.Add(new VideoResponse
                {
                    Id = video.Id,
                    Name = video.Name,
                    AuthorName = video.User.UserName,
                    UrlAddress = video.UrlAddress,
                    DateOfCreate = video.DateOfCreate
                });
            }
            return videosToSend;
        }

        public VideoResponse PrepareVideoToSend(Video video) => new VideoResponse
        {
            Id = video.Id,
            Name = video.Name,
            
            AuthorName = video.User.UserName,
            DateOfCreate = video.DateOfCreate
        };


    }
}
