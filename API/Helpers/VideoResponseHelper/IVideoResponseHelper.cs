using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.VideoResponseHelper
{
    public interface IVideoResponseHelper
    {
        List<VideoResponse> PrepareVideosToSend(List<Video> videos);
    }
}
