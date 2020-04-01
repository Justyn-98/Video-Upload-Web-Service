using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models.Tabels;
using API.Services.Interfaces;

namespace API.Controllers
{
    [Route("[controller]")]
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
        public async Task<ActionResult<VideoCategory>> GetById(string id)
        {
            var response = await _service.VideoCategoryFindResponse(id);

            if (!response.Success)
                return NotFound();

            return response.Data;
        }

        // PUT: api/VideoCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, VideoCategory videoCategory)
        {
            var response = await _service.VideoCategoryUpdateResponse(id, videoCategory);

            if (!response.Success)
                return NotFound();

            return Ok();
        }

        // POST: api/VideoCategories
        [HttpPost]
        public async Task<ActionResult<VideoCategory>> Create(VideoCategory videoCategory)
        {
            var response = await _service.CreateVideoCategoryResponse(videoCategory);

            if (!response.Success)
                return Conflict();

            return CreatedAtAction("GetById", new { id = response.Data.Id }, response.Data);
        }

        // DELETE: api/VideoCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoCategory>> Delete(string id)
        {
            var response = await _service.VideoCategoryFindResponse(id);

            if (!response.Success)
                return NotFound();

            await _service.DeleteVideoCategory(response.Data);

            return response.Data;
        }

    }
}
