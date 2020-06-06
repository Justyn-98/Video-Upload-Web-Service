using System.Threading.Tasks;
using API.Models.Entities;
using API.Services.LikesService;
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
            var response =  _service.GetVideoLikesCountResonse(videoId, User);

            return Ok(response.Data);
        }

        //POST: api/Likes?VideoId={videoId}
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromQuery(Name = "VideoId")]string videoId)
        {
            var response = await _service.CreateLikeResponse(videoId, User);

            if (!response.Success)
                return Conflict(response.Message);

            return NoContent();
        }

        //DELETE: api/Likes?VideoId={videoId}
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<VideoLike>> Unlike([FromQuery]string videoId)
        {
            var response = await _service.DeleteLikeResponse(videoId, User);

            if (!response.Success)
                return Conflict(response.Message);

            return NoContent();
        }
    }
}