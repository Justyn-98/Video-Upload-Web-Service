using API.DataAccessLayer;
using API.Helpers.UserSignInHelper;
using API.Helpers.VideoResponseHelper;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Models.ResponseModels;
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
        private readonly IUserSignInHelper _signInHelper;
        private readonly IVideoResponseHelper _responseHelper;
      

        public VideosService(ApplicationDbContext context, IUserSignInHelper hostEnvironment, IVideoResponseHelper userManager) : base(context)
        {
            _signInHelper = hostEnvironment;
            _responseHelper = userManager;
        }

        public async Task<ServiceResponse<VideoResponse>> GetVideoByIdResponse(string id)
        {
            var video = await Context.Videos.Include(u=>u.User)
                .Where(i=>i.Id.Equals(id)).FirstOrDefaultAsync();

            if (video == null)
                return ServiceResponse<VideoResponse>.Error(new ErrorMessage("Not Found Video"));

            var videoToSend = _responseHelper.PrepareVideoToSend(video);
            return ServiceResponse<VideoResponse>.Ok(videoToSend);
        }

        public async Task<ServiceResponse<VideoResponse>> CreateVideoResponse(ClaimsPrincipal claims, VideoRequest model)
        {
            var signedUserId = _signInHelper.GetSignedUserId(claims);

            var choosenVideoCategory = await Context.VideoCategories.FindAsync(model.VideoCategoryId);

            if (choosenVideoCategory == null)
                return ServiceResponse<VideoResponse>.Error(new ErrorMessage("Not selected Video Category"));

            var video = CreateVideo(signedUserId, model, choosenVideoCategory);
            Context.Videos.Add(video);
            await Context.SaveChangesAsync();

            return ServiceResponse<VideoResponse>.Ok(_responseHelper.PrepareVideoToSend(video));
        }

        private Video CreateVideo(string userId, VideoRequest model, VideoCategory videoCategory)
        {
            return new Video
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Name = model.Name,
                Description = model.Description,
                VideoCategoryId = videoCategory.Id,
                UrlAddress = model.VideoPath
            };
        }

    }
}
