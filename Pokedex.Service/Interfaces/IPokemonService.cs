using Pokedex.Core.Entities;
using Pokedex.Core.Helpers;

namespace Pokedex.Service.Interfaces;

public interface IPokemonService
{
    public Task<Pagination<Pokemon>> GetPokemons(int page, int pageSize, string? name);
    public Task<Pokemon?> GetPokemonById(int id);
    public Task<Pokemon?> PostPokemon(Pokemon pokemon);
    public Task<Pokemon?> PutPokemon(Pokemon pokemon);
    public Task<bool> RemovePokemon(int id);
}
