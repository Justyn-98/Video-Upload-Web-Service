using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models.Entities;
using Microsoft.AspNetCore.Http;
using API.Services.VideoCategoriesService;
using API.Models.RequestModels;

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
        public async Task<ActionResult<VideoCategory>> GetById(string id)
        {
            var response = await _service.VideoCategoryFindResponse(id);

            if (!response.Success)
                return NotFound(response.Message);

            return response.Data;
        }


        // PUT: api/VideoCategories/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(string id,[FromBody] VideoCategoryRequest model)
        {
            var response = await _service.VideoCategoryUpdateResponse(id, model);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }


        // POST: api/VideoCategories
        [HttpPost]
        public async Task<ActionResult<VideoCategory>> Create(VideoCategory videoCategory)
        {
            var response = await _service.CreateVideoCategoryResponse(videoCategory);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id }, response.Data);
        }


        // DELETE: api/VideoCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoCategory>> Delete(string id)
        {
            var response = await _service.DeleteVideoCategory(id);

            if (!response.Success)
                return NotFound(response.Message);
            
            return NoContent();
        }

    }
}
