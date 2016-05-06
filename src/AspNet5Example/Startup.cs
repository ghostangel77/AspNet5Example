using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using AspNet5Example.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
//using AspNet5Example.Options;

namespace AspNet5Example
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var configBuilder = new ConfigurationBuilder()
            //    .AddJsonFile("alertThresholds.js")
            //    .AddJsonFile($"alertThresholds{_hostingEnvironment.EnvironmentName}.json", true);
            //var config = configBuilder.Build();

            //services.Configure<ThresholdOptions>(config);

            //services.AddTransient<ISensorDataService, SensorDataService>();
            services.AddMvc();
            services.AddSingleton<IViewModelService, ViewModelService>();
            services.AddSingleton<ISensorDataService, SensorDataService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            if (_hostingEnvironment.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseIISPlatformHandler();
            //*** changed by app.UseMvcWithDefaultRoute();
            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" });
            //});
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseStatusCodePages(); //app.UseStatusCodePagesWithRedirects("~/error/code{0}");
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
