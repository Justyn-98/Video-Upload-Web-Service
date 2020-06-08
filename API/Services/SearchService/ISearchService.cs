using API.Models.ResponseModels;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.SearchService
{
    public interface ISearchService
    {
        Task<ServiceResponse<List<VideoResponse>>> GetVideosByName(string videoName);
        Task<ServiceResponse<List<VideoResponse>>> GetVideosByVideoCategory(string videoCategoryId);
        Task<ServiceResponse<List<VideoResponse>>> GetVideosFromPlayList(string plyListId);


    }
}
