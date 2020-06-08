using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.SubscriptionResponseHelper
{
    public class SubscriptionResponseHelper : ISubscriptionResponseHelper
    {
        public List<SubscriptionResponse> PrepareSubscriptionToSend(List<Subscription> subscriptions)
        {
            var subscriptionResponses = new List<SubscriptionResponse>();
            foreach(var sub in subscriptions)
            {
                subscriptionResponses.Add(new SubscriptionResponse
                {
                    ChanelAuthorId = sub.ChanelAuthorId,
                    Name = sub.ChanelAuthor.UserName
                });
            }
            return subscriptionResponses;
        }
    }
}
