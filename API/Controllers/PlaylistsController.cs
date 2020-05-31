using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService _service;
      public PlaylistsController(IPlaylistService service)
        {
            _service = service;
        }

        // GET: api/PlayLists
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PlayList>> GetSignedUserPlayLists()
        {
            var response = await _service.GetSignedUserPlaylistsResponse(User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
        // POST: api/PlayLists
        [HttpPost]
        [Authorize]
        public  ActionResult<PlayList> Create(PlayListModel model)
        {
            var response = _service.CreatePlayListResponse(model, User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
        //PUT: api/PlayLists/Insert?PlayListId={playlistId}&VideoId={videoId}
        [HttpPut]
        [Authorize]
        [Route("Insert")]
        public async Task<ActionResult<PlayList>> Insert([FromQuery]string playlistId, string videoId)
        {
            var response = await _service.InsertVideoToPlayListResponse(playlistId,videoId);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //PUT: api/PlayLists/RemoveVideo?PlayListId={playlistId}&VideoId={videoId}
        [HttpPut]
        [Authorize]
        [Route("RemoveVideo")]
        public async  Task<ActionResult<PlayList>> RemoveVideo([FromQuery]string playlistId, string videoId)
        {
            var response = await _service.RemoveVideoFromPlayListResponse(playlistId, videoId);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
    }
}