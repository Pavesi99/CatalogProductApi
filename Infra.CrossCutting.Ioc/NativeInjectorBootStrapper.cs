using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.NomeDaBase;
using Domain.Interfaces.Uow;
using Havan.Persistence.ConnectionStrings;
using Infra.Data.Context;
using Infra.Data.Repositories.ItlSys;
using Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IConfiguration configuration, IServiceCollection services)
        {
            //AppService
            services.AddScoped<ICatalogoProdutosAppService, CatalogoProdutosAppService>();

            //Repository
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICatologoProdutosRepository, CatalogoProdutosRepository>();

            //Uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICatalogoProdutoUnitOfWork, CatalogoProdutoUnitOfWork>();

            //Contexto
            services.AddDbContextPool<CatalogoProdutoContext>((sp, ob) =>
            {
                var cs = sp.GetRequiredService<IConnectionStringProvider>().GetConnectionString("CatalogoProdutoAPI");
                ob.UseSqlServer(cs);
            });
        }
    }
}
