using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models.Entities;
using API.Responses;
using API.Responses.Messages;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCategoriesController : ControllerBase
    {
        private readonly IVideoCategoryService _service;

        public VideoCategoriesController(IVideoCategoryService service)
        {
            _service = service;
        }


        // GET: api/VideoCategories
        [HttpGet]
        public async Task<ActionResult<List<VideoCategory>>> GetAll()
            => await _service.GetVideoCategoriesList();


        // GET: api/VideoCategories/id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VideoCategory>> GetById(string id)
        {
            var response = await _service.VideoCategoryFindResponse(id);

            if (!response.Success)
                return NotFound(response.Message);

            return response.Data;
        }


        // PUT: api/VideoCategories/5
        [Authorize(Roles = )]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Edit(string id, VideoCategory videoCategory)
        {
            var response = await _service.VideoCategoryUpdateResponse(id, videoCategory);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }


        // POST: api/VideoCategories
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VideoCategory>> Create(VideoCategory videoCategory)
        {
            var response = await _service.CreateVideoCategoryResponse(videoCategory);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id }, response.Data);
        }


        // DELETE: api/VideoCategories/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VideoCategory>> Delete(string id)
        {
            var response = await _service.DeleteVideoCategory(id);

            if (!response.Success)
                return NotFound(response.Message);
            
            return NoContent();
        }

    }
}
