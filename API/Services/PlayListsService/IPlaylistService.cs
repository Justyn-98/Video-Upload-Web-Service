using API.Models.Entities;
using API.Models.RequestModels;
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
        Task<ServiceResponse<List<object>>> GetSignedUserPlaylistsResponse(ClaimsPrincipal context);
        Task<ServiceResponse<PlayList>> CreatePlayListResponse(PlayListRequest model, ClaimsPrincipal context);
        Task<ServiceResponse<bool>> InsertVideoToPlayListResponse(string playlistId, string videoId);
        Task<ServiceResponse<bool>> RemoveVideoFromPlayListResponse(string playlistId, string videoId);
    }
}
