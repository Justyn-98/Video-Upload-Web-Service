using API.Models.Entities;
using API.Services.UserRolesServices.Interfaces;
using API.Services.UserRolesServices.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.UserRolesServices
{
    public class DefaultAdminService : IDefaultAdminService
    {

        private readonly UserManager<User> _userManager;

        private string email = "admin@admin.com";
        private string password = "admin1_example_Password";

        public DefaultAdminService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public void CreateTestUser()
        {
            var result = CreateTestUserResult();
            result.Wait();
        }
        private async Task CreateTestUserResult()
        {
            if ( await TestUserNotExist())
            {
                var admin = new User() { Id = "1", UserName = email, Email = email };
                var registerUserResult = await _userManager.CreateAsync(admin, password);
            
                if (registerUserResult.Succeeded)
                    await _userManager.AddToRoleAsync(admin, RolesModel.Admin);   
            }
        }

        private async Task<bool> TestUserNotExist()
        {
            var findTestUserResult = await _userManager.FindByEmailAsync(email);
            return findTestUserResult == null;
        }

    }
}
