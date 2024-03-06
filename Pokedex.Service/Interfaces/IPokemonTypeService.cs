using Pokedex.Core.Entities;
using Pokedex.Core.Helpers;

namespace Pokedex.Service.Interfaces;

public interface IPokemonTypeService
{
    public Task<Pagination<PokemonType>> GetPokemonTypes(int page, int pageSize, string? type);
    public Task<PokemonType?> GetPokemonTypeById(int id);
    public Task<PokemonType?> PostPokemonType(PokemonType pokemonType);
    public Task<PokemonType?> PutPokemonType(PokemonType pokemonType);
    public Task<bool> RemovePokemonType(int id);
}