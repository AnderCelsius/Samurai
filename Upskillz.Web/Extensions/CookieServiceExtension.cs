using Microsoft.Extensions.DependencyInjection;
using System;

namespace Upskillz.Web.Extensions
{
    public static class CookieServiceExtension
    {
        public static void ConfigureCookie(this IServiceCollection services)
        {
            var builder = services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

    }
}
