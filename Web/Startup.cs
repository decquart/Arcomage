using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Infrastructure;
using Arcomage.Interfaces;
using Arcomage.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Modules;
using Web.Models;
using Ninject.Modules;
using Web.Util;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            NinjectModule module = new NinjectRegistrations();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var container = new StandardKernel(module, serviceModule);
            return container;

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ServiceModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }


            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
