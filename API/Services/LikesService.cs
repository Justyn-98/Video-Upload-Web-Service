using API.DataAccessLayer;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services
{
    public class LikesService : DatabaseAccessService, ILikesService
    {
        public LikesService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ServiceResponse<bool>> CreateLikeResponse(string videoId, ClaimsPrincipal context)
        {
            var userId = GetSignedUserId(context);

            if (userId == null)
                return ServiceResponse<bool>.Error(new SingleMessage("User not signed"));

            if (SignedUserLikedVideo(videoId, userId))
                return ServiceResponse<bool>.Error();

            Context.Add(new VideoLike
            {
                Id = Guid.NewGuid().ToString(),
                VideoId = videoId,
                UserId = userId
            });
            await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok();
        }

        public async Task<ServiceResponse<bool>> DeleteLikeResponse(string videoId, ClaimsPrincipal context)
        {
            var userId = GetSignedUserId(context);

            if (userId == null)
                return ServiceResponse<bool>.Error(new SingleMessage("User not signed"));
            try
            {
                var like = Context.Likes.Where(v => v.VideoId.Equals(videoId))
                      .Where(u => u.UserId.Equals(userId));

                Context.Remove(like.FirstOrDefault());
                await Context.SaveChangesAsync();
                return ServiceResponse<bool>.Ok();
            }
            catch (InvalidOperationException)
            {
                return ServiceResponse<bool>.Error(new SingleMessage("User not liked this video"));
            }
        }

        public ServiceResponse<object> GetVideoLikesCount(string videoId, ClaimsPrincipal context)
        {
            var signedUserLiked = false;

            try
            {
                var userId = context.Claims.First(id => id.Type == "Id").Value;
                if (SignedUserLikedVideo(videoId, userId))
                    signedUserLiked = true;
            }
            catch (InvalidOperationException) { }

            var likes = Context.Likes.Where(v => v.VideoId.Equals(videoId)).Count();
            return ServiceResponse<object>.Ok(new { likes, signedUserLiked });
        }

        private bool SignedUserLikedVideo(string videoId, string userId)
        {
            try
            {
                var likes = Context.Likes.Where(v => v.VideoId.Equals(videoId))
                   .Where(u => u.UserId.Equals(userId));
                return likes.Count() > 0;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private string GetSignedUserId(ClaimsPrincipal context)
        {
            try
            {
                var userId = context.Claims.First(id => id.Type == "Id").Value;
                return userId;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
