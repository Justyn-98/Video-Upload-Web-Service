using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ServicesConfiguration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection ConfigurePasswordSettings(this IServiceCollection services)
        {

            services.Configure<IdentityOptions>(options =>
            {
                /*Password settings.*/
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            });

            return services;
        }
    }
}
