using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ResponseModels;
using API.Services.SubscriptionsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : Controller
    {

        private readonly ISubscriptionsService _service;
        public SubscriptionsController(ISubscriptionsService service)
        {
            _service = service;
        }

        //GET:localhost:44302/Subscriptions
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SubscriptionResponse>> GetSignedUserPlayLists()
        {
            var response = await _service.GetUserSubscriptionsResponse(User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //POST:localhost:44302/SubscriptionsChanelAuthorId={chanelAuthorId}
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SubscriptionResponse>> Subscribe()
        {
            return Ok();
        }
        //DELETE:localhost:44302/Subscriptions?ChanelAuthorId={chanelAuthorId}
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SubscriptionResponse>> Unsubscribe()
        {

            return Ok();
        }
    }
}