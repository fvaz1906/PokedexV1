using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Data.Context;
using Pokedex.Data.Repositories;
using Pokedex.Service.Interfaces;
using Pokedex.Service.Services;

namespace Pokedex.Service.Binding;

public class Binding
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));

        // Repositories
        services.AddScoped<PokemonRepository>();
        services.AddScoped<SpriteRepository>();

        //Services
        services.AddScoped<IPokemonService, PokemonService>();
        services.AddScoped<ISpriteService, SpriteService>();
    }
}