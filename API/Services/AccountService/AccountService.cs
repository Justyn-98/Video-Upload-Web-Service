using API.DataAccessLayer;
using API.Helpers.EmailSenderHelper;
using API.Helpers.JWTHelper;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Responses;
using API.Responses.Messages;
using API.Responses.ResponseMessages;
using API.ServiceResponses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.AccountService
{
    public class AccountService : DatabaseAccessService, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSenderHelper _emailSenderHelper;
        private readonly IJWTHelper _jwtHelper;

        private ErrorMessage loginErrorMessage = new ErrorMessage("Email address or password is incorrect");


        public AccountService(ApplicationDbContext context, UserManager<User> userManager,
            IEmailSenderHelper emailSenderHelper, IJWTHelper jwtHelper) : base(context)
        {
            _userManager = userManager;
            _emailSenderHelper = emailSenderHelper;
            _jwtHelper = jwtHelper;
        }

        public async Task<ServiceResponse<string>> AuthenticateUserResponse(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user == null)
                return ServiceResponse<string>.Error(loginErrorMessage);

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

            return passwordIsCorrect ? ServiceResponse<string>.Ok(_jwtHelper.GenerateJSONWebToken(user)) :
                ServiceResponse<string>.Error(loginErrorMessage);
        }

        public async Task<ServiceResponse<bool>> RegisterUserResponse(RegisterRequest model)
        {
            var user = new User { UserName = model.EmailAddress, Email = model.EmailAddress };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _emailSenderHelper.SendRegistrationSuccessfulInfo(user.Email);
                return ServiceResponse<bool>.Ok(new SuccessMessage("Successful registration"));
            }
            else
            {
                return ServiceResponse<bool>.Error(CreateErrorMessages(result));
            }
        }

        private ErrorMessages CreateErrorMessages(IdentityResult result)
        {
            List<string> errorMessages = new List<string>();
            foreach (var error in result.Errors)
            {
                errorMessages.Add(error.Description);
            }
            return new ErrorMessages(errorMessages);
        }


    }
}
