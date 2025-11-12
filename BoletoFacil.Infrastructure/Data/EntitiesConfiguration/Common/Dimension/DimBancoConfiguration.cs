using BoletoFacil.Domain.Core.Entities.Dimension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Common.Dimension;

public class DimBancoConfiguration : IEntityTypeConfiguration<DimBanco>
{
    public void Configure(EntityTypeBuilder<DimBanco> builder)
    {
        builder.ToTable("dimBanco");

        builder.HasKey(db => db.BancoId);

        builder.Property(db => db.Nome).IsRequired().HasMaxLength(150);
        builder.Property(db => db.RazaoSocial).IsRequired().HasMaxLength(150);
    }
}