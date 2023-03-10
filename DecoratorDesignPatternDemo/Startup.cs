using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DecoratorDesignPatternDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DecoratorDesignPatternDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<PlayersService>();
            services.AddScoped(serviceProvider =>
            {
                var memoryCache = serviceProvider.GetService<IMemoryCache>();
                var logger = serviceProvider.GetService<ILogger<PlayersServiceLoggingDecorator>>();

                var playerService = serviceProvider.GetRequiredService<PlayersService>();

                IPlayersService cachingDecorator = new PlayersServiceCachingDecorator(playerService, memoryCache);
                IPlayersService loggingDecorator = new PlayersServiceLoggingDecorator(cachingDecorator, logger);

                return loggingDecorator;
            });

            //services.AddScoped<IPlayersService, PlayersService>();
            //services.Decorate<IPlayersService, PlayersServiceCachingDecorator>();
            //services.Decorate<IPlayersService, PlayersServiceLoggingDecorator>();


            //services.AddScoped<IPlayersService, PlayersService>();
            //services.Decorate<IPlayersService, PlayersServiceCachingDecorator>();

            //if (Environment.IsProduction())
            //{
            //    services.Decorate<IPlayersService, PlayersServiceLoggingDecorator>();
            //}



            //services.AddScoped<IPlayersService, PlayersService>();

            //if (Convert.ToBoolean(Configuration["EnableCaching"]))
            //{
            //    services.Decorate<IPlayersService, PlayersServiceCachingDecorator>();
            //}

            //if (Convert.ToBoolean(Configuration["EnableLogging"]))
            //{
            //    services.Decorate<IPlayersService, PlayersServiceLoggingDecorator>();
            //}

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
