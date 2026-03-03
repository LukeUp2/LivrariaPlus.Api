using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace LivrariaPlus.Api.Extensions
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddUseCases(services);
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddUnitOfWork(services);
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {

        }

        private static void AddRepositories(IServiceCollection services)
        {

        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"));
            });
        }

        private static void AddUseCases(IServiceCollection services)
        {

        }
    }
}