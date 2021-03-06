using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Upskillz.Data;
using Upskillz.Data.Seeder;
using Upskillz.Models;
using Upskillz.Utilities;
using Upskillz.Web.Extensions;
using Upskillz.Web.Helpers;

namespace Upskillz.Web
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
            services.AddDbContext<AppDbContext>(opt =>
              opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            // Configure Identity
            services.ConfigureIdentity();

            // Configure Cookie
            services.ConfigureCookie();

            // Configure Cloudinary
            services.AddCloudinary(CloudinaryServiceExtension.GetAccount(Configuration));

            //Automapper Setup
            services.AddAutoMapper(typeof(MapSetup));
            services.AddAutoMapper(typeof(AutoMapSetup));

            services.AddSingleton(Log.Logger);

            // Add DI for Services
            services.AddDependencyInjection();

            services.AddAuthentication();

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddWebOptimizer();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            Seeder.SeedData(dbContext, userManager, roleManager).GetAwaiter().GetResult();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
