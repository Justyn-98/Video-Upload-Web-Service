using API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.UserSignInService
{
    public interface IUserSignInHelper
    {

        Task<User> GetSignedUser(ClaimsPrincipal claimsPrincipal);
        string GetSignedUserId(ClaimsPrincipal claimsPrincipal);
        bool IsSigned(ClaimsPrincipal claimsPrincipal);

    }
}
