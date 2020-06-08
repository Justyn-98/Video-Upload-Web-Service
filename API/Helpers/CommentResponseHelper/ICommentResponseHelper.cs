using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.CommentResponseHelper
{
    public interface ICommentResponseHelper
    {
        List<CommentResponse> PrepeareCommentsToSend(List<Comment> comments);
        CommentResponse PrepareCommentToSend(Comment comment);
    }
}
