using API.DataAccessLayer;
using API.Models.Entities;
using API.Services;
using API.Services.Interfaces;
using API.Services.UserRolesServices;
using API.Services.UserRolesServices.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<IVideoCategoryService, VideoCategoryService>();
            services.AddScoped<IRolesCreateService, RolesCreateService>();
            services.AddScoped<IDefaultAdminService, DefaultAdminService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

       
            var roleService = serviceProvider.GetRequiredService<IRolesCreateService>();
            roleService.AddRoles();

            var defaultAdminService = serviceProvider.GetRequiredService<IDefaultAdminService>();
            defaultAdminService.CreateTestUser();

        }
    }
}
