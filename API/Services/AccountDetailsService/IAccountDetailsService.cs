using API.Models.Entities;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.AccountDetailsService
{
    public interface IAccountDetailsService
    {
        Task<ServiceResponse<User>> GetSignedUserDetailsResponse(ClaimsPrincipal context);
    }
}
