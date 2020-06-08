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
        public async Task<ActionResult<SubscriptionResponse>> GetSignedUserSubscriptions()
        {
            var response = await _service.GetUserSubscriptionsResponse(User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        //POST:localhost:44302/Subscriptions?ChanelAuthorId={chanelAuthorId}
        [HttpPost()]
        [Authorize]
        public async Task<ActionResult<SubscriptionResponse>> Subscribe([FromQuery(Name = "ChanelAuthorId")]string subId)
        {
            var response = await _service.CreateSubscriptionResponse(subId,User);

            if (!response.Success)
                return Conflict(response.Message);

            return Ok(response.Data);
        }

        //DELETE:localhost:44302/Subscriptions?ChanelAuthorId={chanelAuthorId}
        [HttpDelete()]
        [Authorize]
        public async Task<ActionResult<SubscriptionResponse>> Unsubscribe([FromQuery(Name = "ChanelAuthorId")]string subId)
        {

            var response = await _service.DeleteSubscriptionResponse(subId, User);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }
    }
}