﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using AspNet5Example.Services;
using Microsoft.Extensions.Logging;

namespace AspNet5Example
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ISensorDataService, SensorDataService>();
        }

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseIISPlatformHandler();

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World!");
        //    });
        //}

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseIISPlatformHandler();

        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Hello World!");
        //        await next();
        //    });

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World again!");
        //    });
        //}

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Information);
            var logger = loggerFactory.CreateLogger("info");

            app.UseIISPlatformHandler();

            app.Use(async (context, next) =>
            {
                logger.LogInformation("Before next in first middleware");
                await next();
                logger.LogInformation("After next in first middleware");
            });

            app.Run(async (context) =>
            {
                logger.LogInformation("Second middleware");
                await context.Response.WriteAsync("Hello World again!");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
