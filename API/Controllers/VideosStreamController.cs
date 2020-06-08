using API.Services.VideosService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VideosStreamController : Controller
    {
        private readonly IVideosService _service;

        public VideosStreamController(IVideosService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}