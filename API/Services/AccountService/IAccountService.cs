using API.Models.RequestModels;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<bool>> RegisterUserResponse(RegisterRequest model);
        Task<ServiceResponse<string>> AuthenticateUserResponse(LoginRequest model);


    }
}
