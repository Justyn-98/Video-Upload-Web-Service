using System.Threading.Tasks;
using API.Models.ApiModels;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var response = await _accountService.RegisterUserResponse(model);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
    }
}