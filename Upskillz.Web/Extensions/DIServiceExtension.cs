using Microsoft.Extensions.DependencyInjection;
using Upskillz.Data.Abstractions;
using Upskillz.Data.Implementations;

namespace Upskillz.Web.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services) 
        { 
            services.AddScoped<IUnitOfWork, UnitOfWork >();
        }
    }
}
