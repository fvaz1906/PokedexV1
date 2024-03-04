namespace Pokedex.Core.Entities.Relationship;

public class RelPokemonAndType
{
    public int Id { get; set; }
    public int IdPokemon { get; set; }
    public int IdPokemonType { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool Enabled { get; set; }

    public Pokemon? Pokemon { get; set; }
    public PokemonType? PokemonType { get; set; }
}