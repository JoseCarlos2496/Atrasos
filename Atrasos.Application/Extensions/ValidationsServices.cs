using Atrasos.Application.Interfaces;
using Atrasos.Application.Services;
using Atrasos.Domain.Entities;
using Atrasos.Domain.Interface;
using Atrasos.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Atrasos.Application.Extensions
{
    public static class ValidationsServices
    {
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<Atraso, int>, BaseRepository<Atraso, int>>();

            services.AddTransient<IAtrasoService, AtrasoService>();
            services.AddTransient<IAtrasoRepository, AtrasoRepository>();

            return services;
        }
    }
}