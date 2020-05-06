using API.Models.Entities;
using API.Services.UserRolesServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.UserRolesServices
{
    public class RolesCreateService : IRolesCreateService
    {
        private readonly RoleManager<IdentityRole> _roleManager;


        public RolesCreateService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void AddRoles()
        {
            var adminRoleCreateResult = CreateAdministrator();
            adminRoleCreateResult.Wait();

            var customerRoleCreateResult = CreateCustomer();
            customerRoleCreateResult.Wait();
        }

        private async Task CreateAdministrator()
        {
            var hasAdminRole = await _roleManager.RoleExistsAsync("Administrator");

            if (!hasAdminRole)
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
        }

        private async Task CreateCustomer()
        {
            var hasCustomerRole = await _roleManager.RoleExistsAsync("CustomUser");

            if (!hasCustomerRole)
                await _roleManager.CreateAsync(new IdentityRole("CustomUser"));
        }

    }
}
