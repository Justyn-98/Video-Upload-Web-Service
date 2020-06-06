using API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.UserSignInService
{
    public class UserSignInHelper : IUserSignInHelper
    {

        private readonly UserManager<User> _userManager;

        public UserSignInHelper(UserManager<User> userManager) 
        {
            _userManager = userManager;
        }
        public async Task<User> GetSignedUser(ClaimsPrincipal claimsPrincipal)
        {
            try 
            {
                var userId = claimsPrincipal.Claims.First(id => id.Type == "Id").Value;
                return await _userManager.FindByIdAsync(userId);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public bool IsSigned(ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                var userId = claimsPrincipal.Claims.First(id => id.Type == "Id").Value;
                return userId != null;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public string GetSignedUserId(ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                var userId = claimsPrincipal.Claims.First(id => id.Type == "Id").Value;
                return userId;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
