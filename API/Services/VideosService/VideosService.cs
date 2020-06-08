using API.DataAccessLayer;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Responses;
using API.ServiceResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.VideosService
{
    public class VideosService : DatabaseAccessService, IVideosService
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly UserManager<User> _userManager;
        private HttpClient _client;

        public VideosService(ApplicationDbContext context, IHostEnvironment hostEnvironment, UserManager<User> userManager) : base(context)
        {
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _client = new HttpClient();
        }

        ~VideosService()
        {
            if (_client != null)
                _client.Dispose();
        }
        public async Task<ServiceResponse<string>> UploadVideoResponse(IFormFile Video)
        {
            try
            {
                var uploadedVideoPath = await CopyVideoToStream(Video);
                return ServiceResponse<string>.Ok(uploadedVideoPath);
            }
            catch (Exception)
            {
                return ServiceResponse<string>.Error(new ErrorMessage("Video upload error"));
            }
        }

        public async Task<ServiceResponse<Stream>> GetVideoSteramResponse(string id)
        {
            var video = await Context.Videos.FindAsync(id);

            if (video == null)
                return ServiceResponse<Stream>.Error(new ErrorMessage("Not Found Video"));

            var stream = await _client.GetStreamAsync(video.UrlAddress);
            return ServiceResponse<Stream>.Ok(stream);
        }

        public async Task<ServiceResponse<Video>> CreateVideoResponse(ClaimsPrincipal context, VideoRequest model)
        {
            var signedUser = await GetSignedUser(context);

            if (signedUser == null)
                return ServiceResponse<Video>.Error(new ErrorMessage("The user must be logged in"));

            var choosenVideoCategory = await Context.VideoCategories.FindAsync(model.VideoCategoryId);

            if (choosenVideoCategory == null)
                return ServiceResponse<Video>.Error(new ErrorMessage("Not selected Video Category"));

            var video = CreateVideo(signedUser, model, choosenVideoCategory);
            Context.Videos.Add(video);
            await Context.SaveChangesAsync();

            return ServiceResponse<Video>.Ok(video);
        }

        private Video CreateVideo(User user, VideoRequest model, VideoCategory videoCategory)
        {
            return new Video
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Name = model.Name,
                Description = model.Description,
                VideoCategoryId = videoCategory.Id,
                UrlAddress = model.VideoPath
            };
        }
        private async Task<string> CopyVideoToStream(IFormFile file)
        {
            var uploadFolder = Path.Combine(_hostEnvironment.ContentRootPath, "Resources", "Videos");
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine(uploadFolder, fileName);
        }

        private async Task<User> GetSignedUser(ClaimsPrincipal context)
        {
            var userId = context.Claims.First(id => id.Type == "Id").Value;
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
