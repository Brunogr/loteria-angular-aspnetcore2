using AutoMapper;
using Loteria.Application.Model.AutoMapper;
using Loteria.Application.Service;
using Loteria.Application.Service.Interface;
using Loteria.Infra.Data.Interface;
using Loteria.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Loteria.Infra.CrossCutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(
                sp => AutoMapperConfig.RegisterMappings().CreateMapper());

            //Service
            services.AddScoped<ICartelaService, CartelaService>();
            services.AddScoped<ISorteioService, SorteioService>();

            //Repository
            services.AddScoped<ISorteioRepository, SorteioRepository>();
            services.AddScoped<ICartelaRepository, CartelaRepository>();
        }
    }
}
