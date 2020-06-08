using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Services.PlayListsService;
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
        [HttpPost()]
        [Authorize]
        public async Task<ActionResult<PlayList>> Create(PlayListRequest model)
        {
            var response = await _service.CreatePlayListResponse(model, User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //PATCH: api/PlayLists/Insert?PlayListId={playlistId}&VideoId={videoId}
        [Route("Insertion")]
        [HttpPatch()]
        [Authorize]
        public async Task<ActionResult<PlayList>> Insert(
            [FromQuery(Name = "PlaylistId")]string playlistId, [FromQuery(Name = "VideoId")]string videoId)
        {
            var response = await _service.InsertVideoToPlayListResponse(playlistId, videoId);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //PATCH: api/PlayLists/RemoveVideo?PlayListId={playlistId}&VideoId={videoId}
        [HttpPatch]
        [Authorize]
        [Route("Removal")]
        public async Task<ActionResult<PlayList>> RemoveVideo(
            [FromQuery(Name = "PlaylistId")]string playlistId, [FromQuery(Name = "VideoId")]string videoId)
        {
            var response = await _service.RemoveVideoFromPlayListResponse(playlistId, videoId);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //DELETE: api/PlayLists/{playlistId}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePlayList(string playListId)
        {
            var response = await _service.DeletePlayListResponse(playListId, User);

            if (!response.Success)
                return Conflict(response.Message);

            return NoContent();
        }
    }
}