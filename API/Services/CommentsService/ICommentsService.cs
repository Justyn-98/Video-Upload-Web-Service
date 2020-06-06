using API.Models.ApiModels;
using API.Models.Entities;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.CommentsService
{
    public interface ICommentsService
    {
        Task<ServiceResponse<Comment>> CreateCommentResponse(ClaimsPrincipal user, CommentModel model);
        Task<ServiceResponse<List<object>>> GetVideoCommentsResponse(string videoId);
        Task<ServiceResponse<object>> GetCommentByIdResponse(string id);
        Task<ServiceResponse<bool>> DeleteCommentResponse(string id, ClaimsPrincipal claimsPrincipal);
    }
}
