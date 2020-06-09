using API.Models.Entities;
using API.Models.RequestModels;
using API.Models.ResponseModels;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.PlayListsService
{
    public interface IPlaylistService
    {
        Task<ServiceResponse<List<PlayListResponse>>> GetSignedUserPlaylistsResponse(ClaimsPrincipal context);
        Task<ServiceResponse<PlayList>> CreatePlayListResponse(PlayListRequest model, ClaimsPrincipal context);
        Task<ServiceResponse<bool>> InsertVideoToPlayListResponse(string playlistId, string videoId);
        Task<ServiceResponse<bool>> RemoveVideoFromPlayListResponse(string playlistId, string videoId);
        Task<ServiceResponse<bool>> DeletePlayListResponse(object playlistId, ClaimsPrincipal user);
    }
}
