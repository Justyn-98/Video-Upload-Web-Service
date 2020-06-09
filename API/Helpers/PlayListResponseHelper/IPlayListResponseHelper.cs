using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.PlayListResponseHelper
{
    public interface IPlayListResponseHelper
    {
        public List<PlayListResponse> PreparePlayListsToSend(List<PlayList> signedUserPlaylists);

    }
}
