using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Core.Entities;

namespace Pokedex.Data.Mapping;

public class PokemonTypeMapping
{
    public void Configure(EntityTypeBuilder<PokemonType> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("pokemon_type");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Type).HasColumnName("type");
        entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("create_date");
        entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime")
            .HasColumnName("update_date");
        entity.Property(e => e.Enabled)
            .HasColumnType("bit(1)")
            .HasColumnName("enabled");
    }
}
