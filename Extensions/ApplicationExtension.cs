using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Data;
using LivrariaPlus.Api.Data.Repositories;
using LivrariaPlus.Api.UseCases.Books.Create;
using LivrariaPlus.Api.UseCases.Books.Delete;
using LivrariaPlus.Api.UseCases.Books.GetById;
using LivrariaPlus.Api.UseCases.Books.ListAll;
using LivrariaPlus.Api.UseCases.Update;
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
            services.AddScoped<UnitOfWork>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<BookRepository>();
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
            services.AddScoped<CreateBookUseCase>();
            services.AddScoped<GetBookByIdUseCase>();
            services.AddScoped<ListAllBooksUseCase>();
            services.AddScoped<UpdateBookUseCase>();
            services.AddScoped<DeleteBookUseCase>();
        }
    }
}