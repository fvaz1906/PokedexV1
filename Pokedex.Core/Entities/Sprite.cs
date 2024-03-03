using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Core.Entities;

public class Sprite
{
    public int Id { get; set; }
    public int IdPokemon { get; set; }
    public string Url { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool Enabled { get; set; }

    [ForeignKey("IdPokemon")]
    public Pokemon? Pokemon { get; set; }
}
