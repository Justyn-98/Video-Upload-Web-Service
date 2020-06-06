using API.Models.ApiModels;
using API.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<bool>> RegisterUserResponse(RegisterModel model);
        Task<ServiceResponse<string>> AuthenticateUserResponse(LoginModel model);


    }
}
