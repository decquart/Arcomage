using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public static class ContextConfiguration
    {
        public static IServiceCollection LoadContextConfiguration(this IServiceCollection services, string connStr)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connStr));
            return services;
        }
    }
}
