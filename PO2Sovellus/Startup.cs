using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PO2Sovellus
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        // Constructor for Startup
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            builder.Build();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<ITervehtija, Tervehtija>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ITervehtija tervehtija)
        {
            loggerFactory.AddConsole();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseFileServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandlingPath = "/virhe"
                    //ExceptionHandler = context => context.Response.WriteAsync("Hupsista!")
                });

            }

            //app.UseWelcomePage(new WelcomePageOptions { Path = "/welcome" });

            app.UseMvcWithDefaultRoute();
        }
    }
}
