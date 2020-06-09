using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.PlayListResponseHelper
{
    public class PlayListReponseHelper : IPlayListResponseHelper
    {
        public List<PlayListResponse> PreparePlayListsToSend(List<PlayList> signedUserPlaylists)
        {
            var preparedPlayLists = new List<PlayListResponse>();
            foreach (var plyslist in signedUserPlaylists)
            {
                preparedPlayLists.Add(new PlayListResponse
                {
                    Id = plyslist.Id,
                    Name = plyslist.Name,
                    PlayListAuthor = plyslist.User.Email
                });
            }
            return preparedPlayLists;
        }
    }
}
