using API.DataAccessLayer;
using API.Models.ApiModels;
using API.Models.Entities;
using API.Responses;
using API.Responses.Messages;
using API.ServiceResponses;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class AccountService : DatabaseAccessService, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(ApplicationDbContext context,
            UserManager<User> userManager, SignInManager<User> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ServiceResponse<bool>> RegisterUserResponse(RegisterModel model)
        {
            var user = new User { UserName = model.EmailAddress, Email = model.EmailAddress };
            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded ? ServiceResponse<bool>.Ok(new SingleMessage("Successful registration"))
                : ServiceResponse<bool>.Error(CreateErrorMessages(result));
        }

        private Messages CreateErrorMessages(IdentityResult result)
        {
            List<string> errorMessages = new List<string>();
            foreach (var error in result.Errors)
            {
                errorMessages.Add(error.Description);
            }
            return new Messages(errorMessages);
        }

    }
}
