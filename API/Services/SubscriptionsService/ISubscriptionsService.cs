﻿using API.Models.ResponseModels;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.SubscriptionsService
{
    public interface ISubscriptionsService
    {
        Task<ServiceResponse<List<SubscriptionResponse>>> GetUserSubscriptionsResponse(ClaimsPrincipal claims);
        Task<ServiceResponse<bool>> CreateSubscriptionResponse(string id, ClaimsPrincipal claims);
        Task<ServiceResponse<bool>> DeleteSubscriptionResponse(string id, ClaimsPrincipal claims);

    }
}
