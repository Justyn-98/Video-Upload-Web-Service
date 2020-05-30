using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Services.Interfaces;
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

        // POST: api/Comments/
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> Create(CommentModel model)
        {
            var response = await _service.CreateCommentResponse(User, model);

            if (!response.Success)
                return Conflict(response.Message);

            return CreatedAtAction("GetById", new { id = response.Data.Id }, response.Data.Id);
        }
        //// GET: api/Comments/
        //[HttpGet("{id}")]
        //[Route("Dupa")]
        //public async Task<ActionResult<Comment>> GetById(string id)
        //{


        //    return Ok();
        //}

        // GET: api/Comments?VideoId=id}
        [HttpGet("{videoId}")]
        public async Task<ActionResult<Comment>> GetVideoCommments(string videoId)
        {
            var response = await  _service.GetVideoCommentsPreparedToSend(videoId);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data.ElementAt(0));
        }
    }
}