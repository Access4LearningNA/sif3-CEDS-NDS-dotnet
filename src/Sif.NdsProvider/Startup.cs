﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Web.Http;
using Sif.NdsProvider.Mappers;
using SIF.NDSDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Sif.NdsProvider.Validators;
using FluentValidation.AspNetCore;

namespace SifNdsProvider
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            
            // services.AddMvc().AddXmlSerializerFormatters();
            //   services.AddMvc()
            //.AddMvcOptions(opt => opt.InputFormatters.Add(new XmlDataContractSerializerInputFormatter()));
            services.AddMvc();
            services.AddOptions();
            services.AddMvcCore()
                 .AddJsonFormatters().AddXmlSerializerFormatters();
            services.AddMvcCore(options =>
       {
           options.RequireHttpsPermanent = true; // does not affect api requests
           options.RespectBrowserAcceptHeader = true; // false by default


       });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
            })
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentValidator>());
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CEDSContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddMvc(config =>
            //{
            //    // Add XML Content Negotiation

            //    config.RespectBrowserAcceptHeader = true;
            //    config.InputFormatters.Add(new XmlSerializerInputFormatter());
            //    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            //});

            AutoMapperProfileConfiguration.Configure();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();
           
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });
            
            //appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
