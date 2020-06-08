using API.Models.Entities;
using API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.SubscriptionResponseHelper
{
    public interface ISubscriptionResponseHelper
    {
        List<SubscriptionResponse> PrepareSubscriptionToSend(List<Subscription> subscriptions);
    }
}
