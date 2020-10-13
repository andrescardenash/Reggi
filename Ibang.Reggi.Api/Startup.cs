using Ibang.Reggi.Common.Resources;
using Ibang.Reggi.CrossCutting.Register;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ibang.Reggi.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ConfigureServices.
        /// </summary>
        /// <param name="services">Colección de servicios.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(configuration =>
            {
                ApplicationEnvironment appInfo = PlatformServices.Default.Application;
                List<string> xmlFiles = Directory.GetFiles(appInfo.ApplicationBasePath, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => configuration.IncludeXmlComments(xmlFile));
                configuration.SwaggerDoc("v1", new OpenApiInfo { Title = GlobalResource.SwaggerTitle, Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();

            IoCRegister.AddRegistration(services);
        }

        /// <summary>
        /// Configure.
        /// </summary>
        /// <param name="app">Aplicación.</param>
        /// <param name="env">Ambiente.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(configuration =>
            {
                configuration.SwaggerEndpoint("../swagger/v1/swagger.json", GlobalResource.SwaggerTitle);
                configuration.RoutePrefix = "Documentation";
                configuration.DisplayRequestDuration();
            });
            IoCRegister.AddConfiguration(app, env);
        }
    }
}
