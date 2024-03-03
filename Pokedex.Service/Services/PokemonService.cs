using Pokedex.Core.Entities;
using Pokedex.Core.Helpers;
using Pokedex.Data.Repositories;
using Pokedex.Service.Interfaces;

namespace Pokedex.Service.Services;

public class PokemonService : IPokemonService
{
    private readonly PokemonRepository _pokemonRepository;

    public PokemonService(PokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public async Task<Pagination<Pokemon>> GetPokemons(
        int page,
        int pageSize,
        string? name)
    {
        List<Pokemon> pokemons = await _pokemonRepository.GetPokemons();

        if (!string.IsNullOrEmpty(name))
        {
            pokemons = pokemons.Where(x => x.Name.Contains(name)).ToList();
        }

        return new Pagination<Pokemon>
        {
            Data = pokemons.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            Page = page,
            PageSize = pageSize,
            TotalItems = pokemons.Count()
        };

    }

    public async Task<Pokemon?> GetPokemonById(int id)
    {
        return await _pokemonRepository.GetPokemonById(id);
    }

    public async Task<Pokemon?> PostPokemon(Pokemon pokemon)
    {
        return await _pokemonRepository.PostPokemon(pokemon);
    }

    public async Task<Pokemon?> PutPokemon(Pokemon pokemon)
    {
        return await _pokemonRepository.PutPokemon(pokemon);
    }

    public async Task<bool> RemovePokemon(int id)
    {
        return await _pokemonRepository.RemovePokemon(id);
    }
}
