using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : Controller
    {

        private readonly IVideoService _service;

        public VideosController(IVideoService service)
        {
            _service = service;
        }

        // POST: api/Videos
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Video>> Create(VideoModel model)
        {
            var response = await _service.CreateVideoResponse(User, model);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id }, response.Data);
        }
    }
}