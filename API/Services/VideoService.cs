using API.DataAccessLayer;
using API.Models;
using API.Models.Entities;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services
{
    public class VideoService : DatabaseAccessService, IVideoService
    {
        private readonly UserManager<User> _userManager;
        public VideoService(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<Video>> CreateVideoResponse(ClaimsPrincipal contex, VideoModel model)
        {
            var signedUser = await _userManager.GetUserAsync(contex);

            if (signedUser == null)
                return ServiceResponse<Video>.Error();

            var choosenVideoCategory = await Context.VideoCategories.Where(n=>n.Name.Equals(model.VideoCategoryName)).ToListAsync();

            if(choosenVideoCategory.Count ==0)
                return ServiceResponse<Video>.Error();
        
            var video = new Video
            {
                UserId = signedUser.Id,
                Name = model.Name,
                Description = model.Description,
                VideoCategoryId = choosenVideoCategory.FirstOrDefault().Id,
                UrlAddress = model.UrlAddress
            };

            Context.Videos.Add(video);
            await Context.SaveChangesAsync();

            return ServiceResponse<Video>.Ok();
        }
    }
}
