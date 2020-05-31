using API.DataAccessLayer;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services
{
    public class PlayListsSerivce : DatabaseAccessService, IPlaylistService
    {
        public PlayListsSerivce(ApplicationDbContext context) : base(context)
        {
        }

        public ServiceResponse<PlayList> CreatePlayListResponse(PlayListModel model, ClaimsPrincipal context)
        {
            var userId = context.Claims.First(id => id.Type == "Id").Value;

            if (userId == null)
                return ServiceResponse<PlayList>.Error(new SingleMessage("User not signed"));

            return ServiceResponse<PlayList>.Ok(new PlayList
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Name = model.Name
            });
        }

        public async Task<ServiceResponse<List<object>>> GetSignedUserPlaylistsResponse(ClaimsPrincipal context)
        {
            var userId = context.Claims.First(id => id.Type == "Id").Value;
            
            if (userId == null)
                return ServiceResponse<List<object>>.Error(new SingleMessage("User not signed"));

            var usersWithPlaylists = await Context.Users.Include(p => p.PlayLists).ToListAsync();
            var signedUserPlaylists = usersWithPlaylists.Find(i => i.Id.Equals(userId)).PlayLists;

            return ServiceResponse<List<object>>.Ok(PreparePlayListsToSend(signedUserPlaylists.ToList()));
        }

        public async Task<ServiceResponse<bool>> InsertVideoToPlayListResponse(string playlistId, string videoId)
        {
            var video = await Context.Videos.FindAsync(videoId);
            var playList = await Context.PlayLists.FindAsync(playlistId);
            if (video == null || playList == null)
                return ServiceResponse<bool>.Error();

            var videoOnPlayList = new VideoOnPlayList
            {
                PlayListId = playList.Id,
                VideoId = video.Id
            };
            Context.Add(videoOnPlayList);
            await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok(new SingleMessage("Video added to playlist"));
        }

        public async Task<ServiceResponse<bool>> RemoveVideoFromPlayListResponse(string playlistId, string videoId)
        {
            var videoPlayList = Context.VideoOnPlayLists
                .Where(p => p.PlayListId.Equals(playlistId)).Where(v => v.VideoId.Equals(videoId));
            if (videoPlayList == null)
                return ServiceResponse<bool>.Error();

            Context.Remove(videoPlayList);
            await Context.SaveChangesAsync();

            return ServiceResponse<bool>.Ok();
        }

        private List<object> PreparePlayListsToSend(List<PlayList> signedUserPlaylists)
        {
            var preparedPlayLists = new List<object>();
            foreach (var plyslist in signedUserPlaylists)
            {
                preparedPlayLists.Add(new
                {
                    Id = plyslist.Id,

                    Author = plyslist.User.Email,
                });
            }
            return preparedPlayLists;
        }
    }
}
