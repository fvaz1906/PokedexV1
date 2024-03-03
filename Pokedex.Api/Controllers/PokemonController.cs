using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Entities;
using Pokedex.Service.Interfaces;

namespace Pokedex.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemons(
        int page,
        int pageSize,
        string? name)
        => Ok(await _pokemonService.GetPokemons(page, pageSize, name));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPokemonById(int id) => Ok(await _pokemonService.GetPokemonById(id));

    [HttpPost]
    public async Task<IActionResult> PostPokemon(Pokemon pokemon) => Ok(await _pokemonService.PostPokemon(pokemon));

    [HttpPut]
    public async Task<IActionResult> PutPokemon(Pokemon pokemon) => Ok(await _pokemonService.PutPokemon(pokemon));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePokemon(int id) => Ok(await _pokemonService.RemovePokemon(id));
}
