using Domain.AutoMapper;
using Domain.Interfaces.Generic;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.Repository.Generic;
using Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Impar.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterDomainServices();
            services.RegisterAutoMapper();
        }

        private static void RegisterDomainServices(this IServiceCollection services) {
            services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddScoped<ICarService, CarService>();
            services.AddTransient<ICarRepository,RepositoryCar>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CarMappingProfile));
            services.AddAutoMapper(typeof(PhotoMappingProfile));
        }
    }
}
