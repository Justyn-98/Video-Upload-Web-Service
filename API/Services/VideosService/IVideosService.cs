using API.Models.Entities;
using API.Models.RequestModels;
using API.Models.ResponseModels;
using API.ServiceResponses;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.VideosService
{
    public interface IVideosService
    {
        Task<ServiceResponse<VideoResponse>> CreateVideoResponse(ClaimsPrincipal contex, VideoRequest model);
        Task<ServiceResponse<VideoResponse>> GetVideoByIdResponse(string id);
    }
}
