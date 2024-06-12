using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Base;
using Repositories.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseIdRepository<,>), typeof(BaseIdRepository<,>));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IServiceService, ProjectService>();
            services.AddScoped<DbDataSeeder>();
            return services;
        }
    }
}
