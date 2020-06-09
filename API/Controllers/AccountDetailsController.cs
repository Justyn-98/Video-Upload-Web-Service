using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.AccountDetailsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : Controller
    {

        private readonly IAccountDetailsService _service;
        public AccountDetailsController(IAccountDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSignedUserName()
        {
            var response = await _service.GetSignedUserDetailsResponse(User);
            
            if (!response.Success)
                return BadRequest();

            return Ok(response.Data);
        }
    }
}