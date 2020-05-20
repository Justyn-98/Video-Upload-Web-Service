using API.DataAccessLayer;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services
{
    public class AccountManagementService : DatabaseAccessService, IAccountManagementService
    {
        private readonly UserManager<User> _userManager;
        public AccountManagementService(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<User>> GetSignedUserDetailsResponse(ClaimsPrincipal context)
        {
            var userId = context.Claims.First(id => id.Type == "Id").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return user != null ? ServiceResponse<User>.Ok(user) : ServiceResponse<User>.Error(new SingleMessage("chuj dupa cycki"));
        }
    }
}
