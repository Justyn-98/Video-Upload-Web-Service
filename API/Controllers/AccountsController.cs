using System.Linq;
using System.Threading.Tasks;
using API.Models.ApiModels;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var response = await _accountService.RegisterUserResponse(model);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await _accountService.AuthenticateUserResponse(model);

            if (!response.Success)
                return BadRequest(new { error = response.Message });

            return Ok(new { token = response.Data });
        }
    }
}