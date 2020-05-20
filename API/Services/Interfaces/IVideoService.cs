using API.Models;
using API.Models.Entities;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IVideoService
    {
        public Task<ServiceResponse<Video>> CreateVideoResponse(ClaimsPrincipal contex, VideoModel model);

    }
}
