using API.DataAccessLayer;
using API.Helpers.VideoResponseHelper;
using API.Models.Entities;
using API.Models.ResponseModels;
using API.ServiceResponses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.SearchService
{
    public class SearchService : DatabaseAccessService, ISearchService
    {
        private readonly IVideoResponseHelper _responseHelper;
        public SearchService(ApplicationDbContext context,IVideoResponseHelper responseHelper) : base(context)
        {
            _responseHelper = responseHelper;
        }

        public async Task<ServiceResponse<List<VideoResponse>>> GetVideosByName(string videoName)
        {
            var videosWithUsers = await Context.Videos.Include(u => u.User).ToListAsync();
            var videosByName = videosWithUsers.Where(n => n.Name.Contains(videoName)).ToList();
            var videosToSend = _responseHelper.PrepareVideosToSend(videosByName);
            return ServiceResponse<List<VideoResponse>>.Ok(videosToSend);
        }

        public async Task<ServiceResponse<List<VideoResponse>>> GetVideosByVideoCategory(string videoCategoryId)
        {
            var videosWithUsers = await Context.Videos.Include(u => u.User).ToListAsync();
            var videosByVideoCategory = videosWithUsers.Where(n => n.VideoCategoryId.Equals(videoCategoryId)).ToList();
            var videosToSend = _responseHelper.PrepareVideosToSend(videosByVideoCategory);
            return ServiceResponse<List<VideoResponse>>.Ok(videosToSend);
        }

        public async Task<ServiceResponse<List<VideoResponse>>> GetVideosFromPlayList(string plyListId)
        {
            var videosOnPlaylistWithUsers = await Context.VideoOnPlayLists
                .Include(v => v.Video).ThenInclude(u=>u.User).ToListAsync();
            var videosByPlayListId = videosOnPlaylistWithUsers.Where(n => n.PlayListId.Equals(plyListId)).ToList();
            var videos = new List<Video>();
            foreach(var videoOnPlayList in videosByPlayListId)
            {
                videos.Add(videoOnPlayList.Video);
            }
            var videosToSend = _responseHelper.PrepareVideosToSend(videos);
            return ServiceResponse<List<VideoResponse>>.Ok(videosToSend);
        }
    }
}
