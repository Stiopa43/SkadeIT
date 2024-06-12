using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("dbConnString");
            services.AddDbContext<ProjectDbContext>(opts =>
               opts.UseNpgsql(dbConnectionString, opts => opts.MigrationsAssembly("API")));
            return services;
        }
    }
}
