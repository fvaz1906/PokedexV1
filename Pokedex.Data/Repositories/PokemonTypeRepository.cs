using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pokedex.Core.Entities;
using Pokedex.Data.Context;

namespace Pokedex.Data.Repositories;

public class PokemonTypeRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger _logger;

    public PokemonTypeRepository(
        AppDbContext context,
        ILogger<PokemonRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<PokemonType>> GetPokemonTypes()
    {
        try
        {
            return await _context.PokemonTypes
                    .AsNoTracking()
                        .Include(x => x.RelPokemonAndType)
                        .ThenInclude(x => x.Pokemon)
                            .ThenInclude(x => x.Sprite)
                    .ToListAsync();

        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<PokemonType?> GetPokemonTypeById(int id)
    {
        try
        {
            return await _context.PokemonTypes
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

    public async Task<PokemonType?> PostPokemonType(PokemonType pokemonType)
    {
        try
        {
            pokemonType.CreateDate = DateTime.Now;
            pokemonType.UpdateDate = DateTime.Now;
            pokemonType.Enabled = true;

            _context.PokemonTypes.Add(pokemonType);
            await _context.SaveChangesAsync();
            return pokemonType;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<PokemonType?> PutPokemonType(PokemonType pokemonType)
    {
        try
        {
            PokemonType? pokemonTypeExists = await _context.PokemonTypes.Where(x => x.Id == pokemonType.Id).FirstOrDefaultAsync();
            if (pokemonTypeExists != null)
            {
                pokemonTypeExists.Type = pokemonType.Type;
                pokemonTypeExists.UpdateDate = pokemonType.UpdateDate;
                pokemonTypeExists.Enabled = pokemonType.Enabled;

                _context.PokemonTypes.Update(pokemonTypeExists);
                await _context.SaveChangesAsync();
                return pokemonTypeExists;
            }

            return new PokemonType();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.ToString());
            throw;
        }
    }

    public async Task<bool> RemovePokemonType(int id)
    {
        try
        {
            PokemonType? pokemonTypeExists = await _context.PokemonTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pokemonTypeExists != null)
            {
                _context.PokemonTypes.Remove(pokemonTypeExists);
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