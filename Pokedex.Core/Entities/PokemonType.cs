using Pokedex.Core.Entities.Relationship;

namespace Pokedex.Core.Entities;

public class PokemonType
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool Enabled { get; set; }

    public ICollection<RelPokemonAndType> RelPokemonAndType { get; set; } = null!;
}
