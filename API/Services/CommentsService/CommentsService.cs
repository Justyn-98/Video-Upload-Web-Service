using API.DataAccessLayer;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using API.Services.UserSignInService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.CommentsService
{
    public class CommentsService : DatabaseAccessService, ICommentsService
    {

        private readonly IUserSignInHelper _helper;

        public CommentsService(ApplicationDbContext context, IUserSignInHelper helper) : base(context)
        {
            _helper = helper;
        }

        public async Task<ServiceResponse<Comment>> CreateCommentResponse(
            ClaimsPrincipal context, CommentModel model, string videoId)
        {
            var signedUserId = _helper.GetSignedUserId(context);

            var comment = CreateComment(signedUserId, model, videoId);

            Context.Comments.Add(comment);
            await Context.SaveChangesAsync();

            return ServiceResponse<Comment>.Ok(comment);
        }

        public async Task<ServiceResponse<List<object>>> GetVideoCommentsResponse(string videoId)
        {
            var comments = await Context.Comments.Include(u => u.User).ToListAsync();
            var videoComments = comments.Where(v => v.VideoId == videoId).ToList();

            return ServiceResponse<List<object>>.Ok(PrepeareCommentsToSend(videoComments));
        }

        public async Task<ServiceResponse<object>> GetCommentByIdResponse(string id)
        {
            var commentsWithUsers = await Context.Comments.Include(u => u.User).ToListAsync();
            var comment =  commentsWithUsers.FirstOrDefault(i => i.Id.Equals(id));
            return comment == null ? ServiceResponse<object>.Error(new SingleMessage("Comment not exist")) 
                : ServiceResponse<object>.Ok(PrepareCommentToSend(comment));
        }

        public async Task<ServiceResponse<bool>> DeleteCommentResponse(string id, ClaimsPrincipal claimsPrincipal)
        {
            var userId = _helper.GetSignedUserId(claimsPrincipal);
            var comment = await Context.Comments.Where(c => c.Id.Equals(id))
                .Where(u => u.UserId.Equals(userId)).FirstOrDefaultAsync();
            if (comment == null)
              return  ServiceResponse<bool>.Error(new SingleMessage("Signed user have not acces to delete this comment"));

            Context.Remove(comment);
            await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok();
        }

        private Comment CreateComment(string signedUserId, CommentModel model, string videoId) => new Comment
        {
            Id = Guid.NewGuid().ToString(),
            UserId = signedUserId,
            VideoId = videoId,
            Content = model.Content
        };

        private List<object> PrepeareCommentsToSend(List<Comment> comments)
        {
            var preparedComments = new List<object>();
            foreach (var comment in comments)
            {
                preparedComments.Add(new
                {
                    comment.Id,
                    Author = comment.User.Email,
                    comment.DateOfCreate,
                    comment.Content
                });
            }
            return preparedComments;
        }

        private object PrepareCommentToSend(Comment comment) => new
        {
            comment.Id,
            Author = comment.User.Email,
            comment.DateOfCreate,
            comment.Content
        };
    }
}
