using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pokedex.Core.Entities;
using Pokedex.Data.Context;

namespace Pokedex.Data.Repositories;

public class PokemonRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger _logger;

    public PokemonRepository(
        AppDbContext context,
        ILogger<PokemonRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Pokemon>> GetPokemons()
    {
        try
        {
            return await _context.Pokemons
                .AsNoTracking()
                    .Include(x => x.Sprite)
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<Pokemon?> GetPokemonById(int id)
    {
        try
        {
            return await _context.Pokemons
                .AsNoTracking()
                    .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<Pokemon?> PostPokemon(Pokemon pokemon)
    {
        try
        {
            pokemon.CreateDate = DateTime.Now;
            pokemon.UpdateDate = DateTime.Now;
            pokemon.Enabled = true;

            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
            return pokemon;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<Pokemon?> PutPokemon(Pokemon pokemon)
    {
        try
        {
            Pokemon? pokemonExists = await _context.Pokemons.Where(x => x.Id == pokemon.Id).FirstOrDefaultAsync();
            if (pokemonExists != null)
            {
                pokemonExists.Name = pokemon.Name;
                pokemonExists.BaseExperience = pokemon.BaseExperience;
                pokemonExists.Height = pokemon.Height;
                pokemonExists.Weight = pokemon.Weight;
                pokemonExists.IsDefault = pokemon.IsDefault;
                pokemonExists.LocationAreaEncounters = pokemon.LocationAreaEncounters;
                pokemonExists.Order = pokemon.Order;
                pokemonExists.UpdateDate = pokemon.UpdateDate;
                pokemonExists.Enabled = pokemon.Enabled;

                _context.Pokemons.Update(pokemonExists);
                await _context.SaveChangesAsync();
                return pokemonExists;
            }

            return new Pokemon();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<bool> RemovePokemon(int id)
    {
        try
        {
            Pokemon? pokemonExists = await _context.Pokemons.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pokemonExists != null)
            {
                _context.Pokemons.Remove(pokemonExists);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }
}
