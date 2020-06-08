using API.DataAccessLayer;
using API.Helpers.UserSignInHelper;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.LikesService
{
    public class LikesService : DatabaseAccessService, ILikesService
    {
        private readonly IUserSignInHelper _helper;

        public LikesService(ApplicationDbContext context, IUserSignInHelper helper) : base(context)
        {
            _helper = helper;
        }

        public ServiceResponse<object> GetVideoLikesCountResonse(string videoId, ClaimsPrincipal claimsPrincipal)
        {
            var userId = _helper.GetSignedUserId(claimsPrincipal);
            var signedUserLiked = SignedUserLikedVideo(videoId, userId);
            var likesCount = Context.Likes.Where(v => v.VideoId.Equals(videoId)).ToList().Count();

            return ServiceResponse<object>.Ok(new { likesCount, signedUserLiked });
        }

        public async Task<ServiceResponse<bool>> CreateLikeResponse(string videoId, ClaimsPrincipal claimsPrincipal)
        {
            var userId = _helper.GetSignedUserId(claimsPrincipal);

            if (SignedUserLikedVideo(videoId, userId))
            {
                return ServiceResponse<bool>.Error(new ErrorMessage("User liked this video"));
            }

            var like = CreateVideoLike(videoId, userId);
            Context.Add(like);
            await Context.SaveChangesAsync();

            return ServiceResponse<bool>.Ok();
        }

        public async Task<ServiceResponse<bool>> DeleteLikeResponse(string videoId, ClaimsPrincipal claimsPrincipal)
        {
            var userId = _helper.GetSignedUserId(claimsPrincipal);

            if (!SignedUserLikedVideo(videoId, userId))
            {
                return ServiceResponse<bool>.Error(new ErrorMessage("User did not liked this video"));
            }

            var like = GetSignedUserLike(userId, videoId);
            Context.Remove(like);
            await Context.SaveChangesAsync();

            return ServiceResponse<bool>.Ok();
        }

        private bool SignedUserLikedVideo(string videoId, string userId)
        {
            var likes = Context.Likes.Where(v => v.VideoId.Equals(videoId))
                .Where(u => u.UserId.Equals(userId)).ToList();

            return likes.Count() > 0;
        }

        private VideoLike GetSignedUserLike(string userId, string videoId)
            => Context.Likes.Where(v => v.VideoId.Equals(videoId))
                      .Where(u => u.UserId.Equals(userId)).FirstOrDefault();

        private VideoLike CreateVideoLike(string videoId, string userId) => new VideoLike
        {
            Id = Guid.NewGuid().ToString(),
            VideoId = videoId,
            UserId = userId
        };
    }
}
