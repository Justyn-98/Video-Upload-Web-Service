using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Services.VideosService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : Controller
    {

        private readonly IVideosService _service;

        public VideosController(IVideosService service)
        {
            _service = service;
        }

        // POST: api/Videos/Upload
        [HttpPost]
        [Authorize]
        [Route("Upload")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Video>> Upload([FromForm]IFormFile videoFile)
        {
            var response = await _service.UploadVideoResponse(videoFile);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("Create", new { path = response.Data }, response.Data);
        }

        // POST: api/Videos/Create
        [HttpPost]
        [Authorize]
        [Route("Create")]
        public async Task<ActionResult<Video>> Create(VideoModel model)
        {
            var response = await _service.CreateVideoResponse(User, model);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id },response.Data.Id);
        }

        // GET: api/Videos/id
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<FileStreamResult> GetById(string id)
        {
            var response = await _service.GetVideoSteramResponse(id);

            return  new FileStreamResult(response.Data, "video/mp4");
        }
    }
}