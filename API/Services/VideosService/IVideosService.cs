using API.Models.ApiModels;
using API.Models.Entities;
using API.ServiceResponses;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.VideosService
{
    public interface IVideosService
    {
        Task<ServiceResponse<Video>> CreateVideoResponse(ClaimsPrincipal contex, VideoModel model);
        Task<ServiceResponse<Stream>> GetVideoSteramResponse(string id);
        Task<ServiceResponse<string>> UploadVideoResponse(IFormFile videoFile);
    }
}
