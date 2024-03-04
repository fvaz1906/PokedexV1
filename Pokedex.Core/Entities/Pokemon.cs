using Pokedex.Core.Entities.Relationship;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Core.Entities;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? BaseExperience { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public bool? IsDefault { get; set; }
    public string? LocationAreaEncounters { get; set; }
    public int? Order { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool Enabled { get; set; }

    [InverseProperty("Pokemon")]
    public Sprite? Sprite { get; set; }

    public ICollection<RelPokemonAndType> RelPokemonAndType { get; set; } = null!;
}
