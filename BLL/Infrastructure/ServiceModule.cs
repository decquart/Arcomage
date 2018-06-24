using AutoMapper;
using BLL.DTO;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Infrastructure
{
    public static class ServiceModule
    {

        
        public static IServiceCollection Load(this IServiceCollection services, string connStr)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connStr));

            //var optionsBuilder = 
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
               // cfg.CreateMap<User, ArcomageUserDTO>();

            });

            services.AddSingleton<MapperConfiguration>(mapperConfiguration);
            services.AddSingleton<IMapper>(ctx => new Mapper(mapperConfiguration, type => ctx.GetService(type)));
            return services;
        }


        //    public IServiceCollection Load(this IServiceCollection services, string connectionString)
        //    {
        //        services.AddTransient<IUnitOfWork>(u => new UnitOfWork(connectionString));
        //        var mapperConfiguration = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<User, UserDTO>();

        //        });

        //        services.AddSingleton<MapperConfiguration>(mapperConfiguration);
        //        services.AddSingleton<IMapper>(ctx => new Mapper(mapperConfiguration, type => ctx.GetService(type)));
        //        return services;
        //    }

    }
}
