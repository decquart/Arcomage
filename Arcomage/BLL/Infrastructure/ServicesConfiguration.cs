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
        public static IServiceCollection LoadServicesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IScoreService, ScoreService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
