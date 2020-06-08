using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Models.ResponseModels;
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


        // POST: api/Videos/Create
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VideoResponse>> Create(VideoRequest model)
        {
            var response = await _service.CreateVideoResponse(User, model);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id },response.Data);
        }

        // GET: api/Videos/id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<VideoResponse>> GetById(string id)
        {
            var response = await _service.GetVideoByIdResponse(id);

            return Ok(response.Data);
        }
    }
}