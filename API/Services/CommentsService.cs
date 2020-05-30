using API.DataAccessLayer;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services
{
    public class CommentsService : DatabaseAccessService, ICommentsService
    {

        private readonly UserManager<User> _userManager;

        public CommentsService(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<Comment>> CreateCommentResponse(ClaimsPrincipal context, CommentModel model)
        {
            var signedUser = await GetSignedUser(context);

            if (signedUser == null)
                return ServiceResponse<Comment>.Error(new SingleMessage("The user must be logged in"));

            var comment = CreateComment(signedUser,model);
            Context.Comments.Add(comment);
            await Context.SaveChangesAsync();

            return ServiceResponse<Comment>.Ok(comment);
        }

        public async Task<ServiceResponse<List<object>>> GetVideoCommentsPreparedToSend(string videoId)
        {
            var comments = await Context.Comments.Include(u => u.User).ToListAsync();
            var videoComments = comments.Where(v => v.VideoId == videoId).ToList();

            if (videoComments == null)
                return ServiceResponse<List<object>>.Error(new SingleMessage("Video not found"));

            return ServiceResponse<List<object>>.Ok(PrepeareCommentsToSend(videoComments));
        }

        private Comment CreateComment(User signedUser, CommentModel model)
            => new Comment
            {
                Id = signedUser.Id,
                VideoId = model.VideoId,
                Content = model.Content,
                DateOfCreate = DateTime.Now
            };

        private List<object> PrepeareCommentsToSend(List<Comment> comments)
        {
            var preparedComments = new List<object>();
            foreach (var comment in comments)
            {
                preparedComments.Add(new
                {
                    Id = comment.Id,
                    Author = comment.User.Email,
                    DateOfCreate = comment.DateOfCreate,
                    Content = comment.Content
                });
            }
            return preparedComments;
        }

        private async Task<User> GetSignedUser(ClaimsPrincipal context)
        {
            var userId = context.Claims.First(id => id.Type == "Id").Value;
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
