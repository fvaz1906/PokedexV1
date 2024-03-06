using Pokedex.Core.Entities;
using Pokedex.Core.Helpers;
using Pokedex.Data.Repositories;
using Pokedex.Service.Interfaces;

namespace Pokedex.Service.Services;

public class PokemonTypeService : IPokemonTypeService
{
    private readonly PokemonTypeRepository _pokemonTypeRepository;

    public PokemonTypeService(PokemonTypeRepository pokemonTypeRepository)
    {
        _pokemonTypeRepository = pokemonTypeRepository;
    }

    public async Task<Pagination<PokemonType>> GetPokemonTypes(
        int page,
        int pageSize,
        string? type)
    {
        List<PokemonType> pokemonTypes = await _pokemonTypeRepository.GetPokemonTypes();

        if (!string.IsNullOrEmpty(type))
        {
            pokemonTypes = pokemonTypes.Where(x => x.Type.Contains(type)).ToList();
        }

        return new Pagination<PokemonType>
        {
            Data = pokemonTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            Page = page,
            PageSize = pageSize,
            TotalItems = pokemonTypes.Count()
        };

    }

    public async Task<PokemonType?> GetPokemonTypeById(int id)
    {
        return await _pokemonTypeRepository.GetPokemonTypeById(id);
    }

    public async Task<PokemonType?> PostPokemonType(PokemonType pokemonType)
    {
        return await _pokemonTypeRepository.PostPokemonType(pokemonType);
    }

    public async Task<PokemonType?> PutPokemonType(PokemonType pokemonType)
    {
        return await _pokemonTypeRepository.PutPokemonType(pokemonType);
    }

    public async Task<bool> RemovePokemonType(int id)
    {
        return await _pokemonTypeRepository.RemovePokemonType(id);
    }
}
