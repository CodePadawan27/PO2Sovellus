using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PO2Sovellus.Entities;
using PO2Sovellus.Services;
using Sovellus.Data.Repositories;
using Sovellus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoMapper;
using PO2Sovellus.ViewModels;
using Sovellus.Model.Entities;

namespace PO2Sovellus
{
    public class Startup
    {
        private string _contentRootPath = "";
        public IConfiguration Configuration { get; set; }
        // Constructor for Startup
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            //builder.Build();
            Configuration = builder.Build();

            _contentRootPath = env.ContentRootPath;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSingleton(Configuration);
            services.AddSingleton<ITervehtija, Tervehtija>();
            services.AddScoped<IRavintolaRepository, RavintolaRepository>();
            services.AddScoped<IArviointiRepository, ArviointiRepository > ();
            services.AddLogging();

            string yhteys = Configuration.GetConnectionString("SovellusDb");
            if (yhteys.Contains("%CONTENTROOTPATH%"))
            {
                yhteys = yhteys.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }
            services.AddDbContext<SovellusContext>(options => options.UseSqlServer(yhteys));

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Cookies.ApplicationCookie.LoginPath = "/Tili/Sisaan";
                config.Cookies.ApplicationCookie.LogoutPath = "/Tili/Ulos";
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                config.Lockout.MaxFailedAccessAttempts = 10;
                config.User.RequireUniqueEmail = false;
            })
                   .AddErrorDescriber<CustomIdentityErrorDescriber>()
                   .AddEntityFrameworkStores<SovellusIdentityDbContext>();
            services.AddDbContext<SovellusIdentityDbContext>(options => options.UseSqlServer(yhteys));

            //Automapper-kirjaston käytön alustus
            Mapper.Initialize(config =>
            {
                config.CreateMap<RavintolaApiViewModel, Ravintola>().ReverseMap();
                config.CreateMap<ArviointiApiViewModel, Arviointi>().ReverseMap();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ITervehtija tervehtija)
        {
            loggerFactory.AddConsole();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);

            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandlingPath = "/virhe"
                    //ExceptionHandler = context => context.Response.WriteAsync("Hupsista!")
                });
                loggerFactory.AddDebug(LogLevel.Error);

            }

            //app.UseWelcomePage(new WelcomePageOptions { Path = "/welcome" });

            app.UseIdentity();
            app.UseMvc(ConfigureRoutes);

            //app.Run(context => context.Response.WriteAsync("Sivua ei löytynyt."));

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Oletus", "{controller=Etusivu}/{action=Index}/{id?}");
        }
    }
}
