using API.MessageHandler;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Configurations
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                next(app);
                app.ApplicationServices.CreateScope().ServiceProvider.GetService<CatalogoProdutosMessageHandler>().IniciarReceiver();
            };
        }
    }
}