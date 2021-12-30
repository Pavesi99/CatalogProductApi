using Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
