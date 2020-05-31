using API.Models.ApiModels;
using API.Models.Entities;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IPlaylistService
    {
        Task<ServiceResponse<List<object>>> GetSignedUserPlaylistsResponse(ClaimsPrincipal context);
        ServiceResponse<PlayList> CreatePlayListResponse(PlayListModel model, ClaimsPrincipal context);
        Task<ServiceResponse<bool>> InsertVideoToPlayListResponse(string playlistId, string videoId);
        Task<ServiceResponse<bool>> RemoveVideoFromPlayListResponse(string playlistId, string videoId);
    }
}
