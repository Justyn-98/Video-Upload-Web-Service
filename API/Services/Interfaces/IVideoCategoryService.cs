using API.Models.Entities;
using API.ServiceResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IVideoCategoryService
    {
        public Task<ActionResult<List<VideoCategory>>> GetVideoCategoriesList();
        public Task<ServiceResponse<VideoCategory>> VideoCategoryFindResponse(string id);
        public Task<ServiceResponse<bool>> DeleteVideoCategory(string id);
        public Task<ServiceResponse<int>> VideoCategoryUpdateResponse(string id, VideoCategory videoCategory);
        public Task<ServiceResponse<VideoCategory>> CreateVideoCategoryResponse(VideoCategory videoCategory);

    }
}
