using API.MessageHandler;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Integration;
using Domain.Interfaces.NomeDaBase;
using Domain.Interfaces.Uow;
using Infra.Data.Context;
using Infra.Data.Repositories.ItlSys;
using Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IConfiguration configuration, IServiceCollection services)
        {
            //MensageHandler
            services.AddScoped<ICatalogoProdutosMessageHandler, CatalogoProdutosMessageHandler>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();

            //AppService
            services.AddScoped<ICatalogoProdutosAppService, CatalogoProdutosAppService>();

            //Repository
            services.AddScoped<ICatologoProdutosRepository, CatalogoProdutosRepository>();

            //Uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICatalogoProdutoUnitOfWork, CatalogoProdutoUnitOfWork>();

            //Contexto
            services.AddDbContextPool<CatalogoProdutoContext>((sp, ob) =>
            {
                ob.UseSqlServer(configuration.GetConnectionString("CatalogoProdutoAPI"));
            });
        }
    }
}
