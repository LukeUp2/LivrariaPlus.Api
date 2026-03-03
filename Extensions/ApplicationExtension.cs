using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        private static void AddUseCases(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}