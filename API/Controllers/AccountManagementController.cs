using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManagementController : Controller
    {

        private readonly IAccountManagementService _service;
        public AccountManagementController(IAccountManagementService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSignedUserName()
        {
            var response = await _service.GetSignedUserDetailsResponse(User);
            
            if (!response.Success)
                return BadRequest();

            return Ok(response.Data);
        }
    }
}