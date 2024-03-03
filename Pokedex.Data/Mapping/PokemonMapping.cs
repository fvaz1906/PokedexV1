using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Core.Entities;

namespace Pokedex.Data.Mapping;

public class PokemonMapping : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("pokemon");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.BaseExperience).HasColumnName("base_experience");
        entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("create_date");
        entity.Property(e => e.Enabled)
            .HasColumnType("bit(1)")
            .HasColumnName("enabled");
        entity.Property(e => e.Height).HasColumnName("height");
        entity.Property(e => e.IsDefault)
            .HasColumnType("bit(1)")
            .HasColumnName("is_default");
        entity.Property(e => e.LocationAreaEncounters)
            .HasMaxLength(255)
            .HasColumnName("location_area_encounters");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");
        entity.Property(e => e.Order).HasColumnName("order");
        entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime")
            .HasColumnName("update_date");
        entity.Property(e => e.Weight).HasColumnName("weight");
    }
}
