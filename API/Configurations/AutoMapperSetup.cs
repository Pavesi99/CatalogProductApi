using Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Configurations
{
    public static class AutoMapperSetup
    {
        /// <summary>
        /// Configura o automapper
        /// </summary>
        /// <param name="services">Coleção de serviços</param>
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
        }
    }
}
