
using Arcomage.Infrastructure;
using Arcomage.Interfaces;
using Arcomage.Services;
using DIContainer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IUserService, UserService>();
            services.Load(Configuration.GetConnectionString("DefultConnection"));


            // NinjectModule module = new NinjectRegistrations();
            // NinjectModule serviceModule = new ServiceModule(Configuration.GetConnectionString("DefaultConnection"));
            // var  container = new StandardKernel(module, serviceModule);

            //// var Kernel = new KernelConfiguration(module, serviceModule);

            // return container;

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ServiceModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
