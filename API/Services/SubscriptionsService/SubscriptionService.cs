using API.DataAccessLayer;
using API.Helpers.SubscriptionResponseHelper;
using API.Helpers.UserSignInHelper;
using API.Models.Entities;
using API.Models.ResponseModels;
using API.Responses;
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

        public async Task<ServiceResponse<bool>> CreateSubscriptionResponse(string id, ClaimsPrincipal claims)
        {
            var userId = _signInHelper.GetSignedUserId(claims);
            var subscriptionCheck =  Context.Subscriptions.Where(u=>u.SubscriberId.Equals(userId))
                .Where(ch=>ch.ChanelAuthorId.Equals(id)).FirstOrDefault();
            if (subscriptionCheck != null)
                return ServiceResponse<bool>.Error(new ErrorMessage("Subscription Exist"));

            var subscription = new Subscription()
            {
                SubscriberId = userId,
                ChanelAuthorId = id
            };
            Context.Add(subscription);
           await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok();
        }

        public async Task<ServiceResponse<bool>> DeleteSubscriptionResponse(string id, ClaimsPrincipal claims)
        {
            var userId = _signInHelper.GetSignedUserId(claims);
            var subscription = Context.Subscriptions.Where(u => u.SubscriberId.Equals(userId))
                .Where(ch => ch.ChanelAuthorId.Equals(id)).FirstOrDefault();
            if (subscription == null)
                return ServiceResponse<bool>.Error(new ErrorMessage("Subscription Not Exist"));

            Context.Remove(subscription);
            await Context.SaveChangesAsync();
            return ServiceResponse<bool>.Ok();
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
