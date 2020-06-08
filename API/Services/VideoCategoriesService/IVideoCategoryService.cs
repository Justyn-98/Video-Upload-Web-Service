using API.Models.Entities;
using API.Models.RequestModels;
using API.ServiceResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.VideoCategoriesService
{
    public interface IVideoCategoryService
    {
        Task<ActionResult<List<VideoCategory>>> GetVideoCategoriesList();
        Task<ServiceResponse<VideoCategory>> VideoCategoryFindResponse(string id);
        Task<ServiceResponse<bool>> DeleteVideoCategory(string id);
        Task<ServiceResponse<int>> VideoCategoryUpdateResponse(string id, VideoCategoryRequest model);
        Task<ServiceResponse<VideoCategory>> CreateVideoCategoryResponse(VideoCategory videoCategory);

    }
}
