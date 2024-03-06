using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Entities;
using Pokedex.Service.Interfaces;

namespace Pokedex.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PokemonTypeController : ControllerBase
{
    private readonly IPokemonTypeService _pokemonTypeService;

    public PokemonTypeController(IPokemonTypeService pokemonTypeService)
    {
        _pokemonTypeService = pokemonTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemonTypes(
        int page,
        int pageSize,
        string? type)
        => Ok(await _pokemonTypeService.GetPokemonTypes(page, pageSize, type));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPokemonTypeById(int id) => Ok(await _pokemonTypeService.GetPokemonTypeById(id));

    [HttpPost]
    public async Task<IActionResult> PostPokemonType(PokemonType pokemonType) => Ok(await _pokemonTypeService.PostPokemonType(pokemonType));

    [HttpPut]
    public async Task<IActionResult> PutPokemonType(PokemonType pokemonType) => Ok(await _pokemonTypeService.PutPokemonType(pokemonType));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePokemonType(int id) => Ok(await _pokemonTypeService.RemovePokemonType(id));
}
