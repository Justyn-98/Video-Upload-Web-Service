using API.DataAccessLayer;
using API.Models.Entities;
using API.Models.RequestModels;
using API.Responses;
using API.Responses.Messages;
using API.ServiceResponses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.AccountService
{
    public class AccountService : DatabaseAccessService, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private IConfiguration _config;

        public AccountService(ApplicationDbContext context,
            UserManager<User> userManager, IConfiguration config) : base(context)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<ServiceResponse<string>> AuthenticateUserResponse(LoginRequest model)
        {
            var errorMessage = new ErrorMessage("Email address or password is incorrect");

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user == null)
                return ServiceResponse<string>.Error(errorMessage);

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

            return passwordIsCorrect ? ServiceResponse<string>.Ok(GenerateJSONWebToken(user)) :
                ServiceResponse<string>.Error(errorMessage);
        }

        public async Task<ServiceResponse<bool>> RegisterUserResponse(RegisterRequest model)
        {
            var user = new User { UserName = model.EmailAddress, Email = model.EmailAddress };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded ? ServiceResponse<bool>.Ok(new ErrorMessage("Successful registration"))
                : ServiceResponse<bool>.Error(CreateErrorMessages(result));
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

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1)

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private object SecurityTokenDescriptor()
        {
            throw new NotImplementedException();
        }
    }
}
