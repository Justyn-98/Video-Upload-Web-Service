using API.DataAccessLayer;
using API.Helpers.UserSignInHelper;
using API.Models.Entities;
using API.Responses;
using API.ServiceResponses;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services.AccountDetailsService
{
    public class AccountDeatilsService : DatabaseAccessService, IAccountDetailsService
    {
        private readonly IUserSignInHelper _signInHelper;
        public AccountDeatilsService(ApplicationDbContext context, IUserSignInHelper signInHelper) : base(context)
        {
            _signInHelper = signInHelper;
        }

        public async Task<ServiceResponse<User>> GetSignedUserDetailsResponse(ClaimsPrincipal context)
        {
            var user = await _signInHelper.GetSignedUser(context);
            return user != null ? ServiceResponse<User>.Ok(user) : ServiceResponse<User>.Error(new ErrorMessage("Not Found user"));
        }
    }
}
