using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Entities;
using Pokedex.Data.Mapping;

namespace Pokedex.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

        modelBuilder.ApplyConfiguration(new PokemonMapping());
        modelBuilder.ApplyConfiguration(new SpriteMapping());

        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Pokemon> Pokemons { get; set; }
    public virtual DbSet<Sprite> Sprites { get; set; }
}