﻿using API.DataAccessLayer;
using API.Helpers.PlayListResponseHelper;
using API.Helpers.UserSignInHelper;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Models.ResponseModels;
using API.Responses;
using API.ServiceResponses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.PlayListsService
{
    public class PlayListsSerivce : DatabaseAccessService, IPlaylistService
    {
        private readonly IUserSignInHelper _signInHelper;
        private readonly IPlayListResponseHelper _repsonseHelpser;

        public PlayListsSerivce(ApplicationDbContext context, IUserSignInHelper helper, IPlayListResponseHelper responseHelper) : base(context)
        {
            _signInHelper = helper;
            _repsonseHelpser = responseHelper;
        }

        public async Task<ServiceResponse<PlayList>> CreatePlayListResponse(PlayListRequest model, ClaimsPrincipal claimsPrincipal)
        {
            var userId = _signInHelper.GetSignedUserId(claimsPrincipal);

            var playlist = new PlayList
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Name = model.Name
            };
            Context.Add(playlist);
            await Context.SaveChangesAsync();
            return ServiceResponse<PlayList>.Ok(playlist);
        }

        public async Task<ServiceResponse<bool>> DeletePlayListResponse(object playlistId, ClaimsPrincipal user)
        {
            var userId = _signInHelper.GetSignedUserId(user);
            var playList = await Context.PlayLists.FindAsync(playlistId);
            if (playList == null)
                return ServiceResponse<bool>.Error(new ErrorMessage("PlayList Not exist"));
           
            Context.Remove(playList);
            await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok();
        }

        public async Task<ServiceResponse<List<PlayListResponse>>> GetSignedUserPlaylistsResponse(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _signInHelper.GetSignedUserId(claimsPrincipal);

            var usersWithPlaylists = await Context.Users.Include(p => p.PlayLists).ToListAsync();
            var signedUserPlaylists = usersWithPlaylists.Find(i => i.Id.Equals(userId)).PlayLists.ToList();
            var playListToSend = _repsonseHelpser.PreparePlayListsToSend(signedUserPlaylists);

            return ServiceResponse<List<PlayListResponse>>.Ok(playListToSend);
        }

        public async Task<ServiceResponse<bool>> InsertVideoToPlayListResponse(string playlistId, string videoId)
        { 
            var video = await Context.Videos.FindAsync(videoId);
            var playList = await Context.PlayLists.FindAsync(playlistId);
            if (video == null || playList == null)
                return ServiceResponse<bool>.Error(new ErrorMessage("Not Found video Or playlist"));

            var videoOnPlayList = new VideoOnPlayList
            {
                PlayListId = playList.Id,
                VideoId = video.Id
            };
            Context.Add(videoOnPlayList);
            await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok(new ErrorMessage("Video added to playlist"));
        }

        public async Task<ServiceResponse<bool>> RemoveVideoFromPlayListResponse(string playlistId, string videoId)
        {
            var videoPlayList = await Context.VideoOnPlayLists.Where(p => p.PlayListId.Equals(playlistId))
                .Where(v => v.VideoId.Equals(videoId)).FirstOrDefaultAsync();
            
            if (videoPlayList == null)
                return ServiceResponse<bool>.Error(new ErrorMessage("Not Found claims resource"));

            Context.Remove(videoPlayList);
            await Context.SaveChangesAsync();

            return ServiceResponse<bool>.Ok();
        }

    }
}
