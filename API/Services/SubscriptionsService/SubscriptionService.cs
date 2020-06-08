using API.DataAccessLayer;
using API.Helpers.SubscriptionResponseHelper;
using API.Helpers.UserSignInHelper;
using API.Models.ResponseModels;
using API.ServiceResponses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.SubscriptionsService
{
    public class SubscriptionService : DatabaseAccessService, ISubscriptionsService
    {

        private readonly IUserSignInHelper _signInHelper;
        private readonly ISubscriptionResponseHelper _responseHelper;

        public SubscriptionService(ApplicationDbContext context, IUserSignInHelper helper,
            ISubscriptionResponseHelper reponseHelper) : base(context)
        {
            _signInHelper = helper;
            _responseHelper = reponseHelper;
        }

        public async Task<ServiceResponse<List<SubscriptionResponse>>> GetUserSubscriptionsResponse(ClaimsPrincipal claims)
        {
            var userId =_signInHelper.GetSignedUserId(claims);
            var subscriptions = await Context.Subscriptions.Include(a => a.ChanelAuthor).ToListAsync();
            var signdeUserSubscriptions = subscriptions.Where(s => s.SubscriberId.Equals(userId)).ToList();
            var subscriptionsToSend = _responseHelper.PrepareSubscriptionToSend(signdeUserSubscriptions);
            return ServiceResponse<List<SubscriptionResponse>>.Ok(subscriptionsToSend);
        }
    }
}
