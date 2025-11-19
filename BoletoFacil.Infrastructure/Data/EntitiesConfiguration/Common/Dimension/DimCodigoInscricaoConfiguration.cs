using BoletoFacil.Domain.Core.Entities.Dimension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Common.Dimension;

public class DimCodigoInscricaoConfiguration : IEntityTypeConfiguration<DimCodigoInscricao>
{
    public void Configure(EntityTypeBuilder<DimCodigoInscricao> builder)
    {
        builder.ToTable("dimCodigoInscricao");

        builder.HasKey(ci => ci.CodigoInscricaoId);

        builder.Property(ci => ci.Nome).IsRequired().HasMaxLength(150);
    }
}
