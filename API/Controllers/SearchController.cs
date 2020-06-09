using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ResponseModels;
using API.Services.SearchService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {

        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service;
        }

        //GET localhost:44302/Search?VideoName={videoName}
        [HttpGet()]
        [AllowAnonymous]
        [Route("ByName")]
        public async Task<IActionResult> SearchByName([FromQuery(Name = "VideoName")]string videoName)
        {
            var response = await _service.GetVideosByName(videoName);
            return Ok(response.Data);
        }

        //GETlocalhost:44302/Search?VideoName={videoName}
        [HttpGet()]
        [AllowAnonymous]
        [Route("ByVideoCategory")]
        public async Task<IActionResult> SearchByVideoCategory([FromQuery(Name = "VideoCategoryId")]string videoCategoryId)
        {
            var response = await _service.GetVideosByVideoCategory(videoCategoryId);
            return Ok(response.Data);
        }

        //GETlocalhost:44302/Search?VideoName={videoName}
        [HttpGet()]
        [AllowAnonymous]
        [Route("ByPlayList")]
        public async Task<IActionResult> SearchByPlayList([FromQuery(Name = "PlayListId")]string playListId)
        {
            var response = await _service.GetVideosFromPlayList(playListId);
            return Ok(response.Data);
        }
    }
}