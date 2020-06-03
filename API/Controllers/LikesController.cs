using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : Controller
    {
        private readonly ILikesService _service;
        public LikesController(ILikesService service)
        {
            _service = service;
        }

        //GET: api/Likes?VideoId={videoId}
        [HttpGet()]
        [AllowAnonymous]
        public  ActionResult<VideoLike> GetLikes([FromQuery(Name = "VideoId")]string videoId)
        {
            var response =  _service.GetVideoLikesCount(videoId, User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //POST: api/Likes
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VideoLike>> Create([FromQuery(Name = "VideoId")]string videoId)
        {
            var response = await _service.CreateLikeResponse(videoId, User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //DELETE: api/Likes
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<VideoLike>> Unlike([FromQuery]string videoId)
        {
            var response = await _service.DeleteLikeResponse(videoId, User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
    }
}