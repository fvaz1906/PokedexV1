using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Core.Entities;

namespace Pokedex.Data.Mapping;

public class SpriteMapping : IEntityTypeConfiguration<Sprite>
{
    public void Configure(EntityTypeBuilder<Sprite> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("sprite");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.IdPokemon).HasColumnName("id_pokemon");
        entity.Property(e => e.Url).HasColumnName("url");

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