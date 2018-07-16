using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoCastles.Entities;
using TwoCastles.Web.DTO;

namespace TwoCastles.Web.Configs
{
    public static class MapperConfiguration
    {
        public static IServiceCollection LoadMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Card, CardDto>();
            });

            services.AddSingleton(mapperConfiguration);
            services.AddSingleton<IMapper>(ctx => new Mapper(mapperConfiguration, type => ctx.GetService(type)));
            return services;
        }
    }
}
