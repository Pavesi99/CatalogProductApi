using Domain.Interfaces.NomeDaBase;
using Infra.Data.Repositories.ItlSys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories.ModuleInstaller
{
    public static class CategoriaModuleInstallerRepository
    {
        public static IServiceCollection addCategoriaRepository(this IServiceCollection service)
        {
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            return service;
        }
    }
}
