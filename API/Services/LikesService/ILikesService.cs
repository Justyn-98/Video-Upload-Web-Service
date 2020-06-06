using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.LikesService
{
    public interface ILikesService
    {
        ServiceResponse<object> GetVideoLikesCountResonse(string videoId, ClaimsPrincipal user);
        Task<ServiceResponse<bool>> CreateLikeResponse(string videoId, ClaimsPrincipal user);
        Task<ServiceResponse<bool>> DeleteLikeResponse(string videoId, ClaimsPrincipal user);
    }
}
