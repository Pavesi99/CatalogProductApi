using API.Configurations;
using API.MessageHandler;
using Havan.AspNetCore.Core;
using Havan.AspNetCore.Swashbuckle;
using Havan.Logistica.Core.Extensions;
using Infra.CrossCutting.Ioc;
using Infra.Data.Config;
using Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace API
{
    public class Startup : ConfigurableStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
            Options.UseCors = true;
            Options.UseControllers = ControllersUsage.UseControllersOnly;
            Options.UseMixedAuthenticationSchema = true;
            Actions.ConfigureJson = e => ConfigureJson(e.Context);
        }

        private static void ConfigureJson(MvcNewtonsoftJsonOptions options)
        {
            options.UseCamelCasing(true);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddLogisticaCore();
            services.AddConnectionStringProvider();
            services.AddAutoMapperSetup();
            services.AddSwaggerDefaultConfiguration(new SwaggerInfo()
            {
                Version = "v1",
                Title = "API base",
                Description = "API base para crair apis.",
                RoutePrefix = "swagger"
            });

            services.AddSwaggerGen(opt =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.Configure<DatabaseAlias>(Configuration.GetSection("DatabaseAlias"));
            NativeInjectorBootStrapper.RegisterServices(Configuration, services);

            // .NET Native DI Abstraction
            RegisterServices(services);

            base.ConfigureServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<CatalogoProdutosMessageHandler>();
            services.AddTransient<IStartupFilter, Api.Configurations.StartupFilter>();
        }
    }
}