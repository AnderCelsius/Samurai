using Microsoft.Extensions.DependencyInjection;
using Upskillz.Core.Interfaces;
using Upskillz.Core.Services;
using Upskillz.Data.Abstractions;
using Upskillz.Data.Implementations;

namespace Upskillz.Web.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services) 
        { 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ISamuraiService, SamuraiService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
