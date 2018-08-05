using Autofac;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static ContainerBuilder RegisterTypes(this ContainerBuilder containerBuilder)
        {
            // Register your own services within Autofac
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            containerBuilder.RegisterType<ScoreService>().As<IScoreService>();
            containerBuilder.RegisterType<GameService>().As<IGameService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            return containerBuilder;
        }
    }
}
