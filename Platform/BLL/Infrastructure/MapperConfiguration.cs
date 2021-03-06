﻿using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public static class MapperConfiguration
    {
        public static IServiceCollection LoadMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<UserDtoForRegister, User>();
                cfg.CreateMap<User, UserDtoForRegister>();

                cfg.CreateMap<Game, GameDto>();
                cfg.CreateMap<GameDto, Game>();
            });

            services.AddSingleton(mapperConfiguration);
            services.AddSingleton<IMapper>(ctx => new Mapper(mapperConfiguration, type => ctx.GetService(type)));
            return services;
        }
    }
}
