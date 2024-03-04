using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities;

public class PokemonType
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool Enabled { get; set; }
}
