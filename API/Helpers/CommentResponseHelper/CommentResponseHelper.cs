using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.CommentResponseHelper
{
    public class CommentResponseHelper : ICommentResponseHelper
    {
        public List<CommentResponse> PrepeareCommentsToSend(List<Comment> comments)
        {
            var preparedComments = new List<CommentResponse>();
            foreach (var comment in comments)
            {
                preparedComments.Add(new CommentResponse
                {
                    Id = comment.Id,
                    Author = comment.User.Email,
                    DateOfCreate = comment.DateOfCreate,
                    Content = comment.Content
                });
            }
            return preparedComments;
        }

        public CommentResponse PrepareCommentToSend(Comment comment)
            => new CommentResponse
            {
                Id = comment.Id,
                Author = comment.User.Email,
                DateOfCreate = comment.DateOfCreate,
                Content = comment.Content
            };
    }
}
