using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Services.CommentsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _service;
        public CommentsController(ICommentsService service)
        {
            _service = service;
        }

        // POST: api/Comments
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> Create(CommentModel model)
        {
            var response = await _service.CreateCommentResponse(User, model);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id },response.Data);
        }

        // GET: api/Comments/
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetById(string id)
        {
            var response = await _service.GetCommentByIdResponse(id);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        // GET: api/Comments?VideoId=id}
        [HttpGet()]
        public async Task<ActionResult<Comment>> GetVideoCommments([FromQuery(Name = "VideoId")]string videoId)
        {
            var response = await  _service.GetVideoCommentsResponse(videoId);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        // GET: api/Comments
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _service.DeleteCommentResponse(id, User);

            if (!response.Success)
                return Conflict(response.Message);

            return NoContent();
        }
    }
}