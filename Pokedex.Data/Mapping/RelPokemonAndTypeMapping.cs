using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Core.Entities.Relationship;

namespace Pokedex.Data.Mapping;

public class RelPokemonAndTypeMapping : IEntityTypeConfiguration<RelPokemonAndType>
{
    public void Configure(EntityTypeBuilder<RelPokemonAndType> entity)
    {
        entity.ToTable("rel_pokemon_type");
        entity.HasKey(e => e.Id).HasName("PRIMARY");
        entity.HasKey(x => new { x.IdPokemon, x.IdPokemonType });

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.IdPokemon).HasColumnName("pokemon_id");
        entity.Property(e => e.IdPokemonType).HasColumnName("pokemon_type_id");
        entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("create_date");
        entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime")
            .HasColumnName("update_date");
        entity.Property(e => e.Enabled)
            .HasColumnType("bit(1)")
            .HasColumnName("enabled");

        entity
            .HasOne(x => x.Pokemon)
            .WithMany(y => y.RelPokemonAndType)
            .HasForeignKey(x => x.IdPokemon);

        entity
            .HasOne(x => x.PokemonType)
            .WithMany(y => y.RelPokemonAndType)
            .HasForeignKey(x => x.IdPokemonType);
    }
}
