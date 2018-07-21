using Microsoft.Extensions.DependencyInjection;
using TwoCastles.Data.Interfaces;
using TwoCastles.Data.Repositories;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;
using TwoCastles.GameLogic.Services;

namespace TwoCastles.Web.Configs
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection LoadServicesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IDeckService, DeckService>();
            services.AddTransient<IApiService, ApiService>();
            services.AddScoped<Game>();
            return services;
        }
    }
}
