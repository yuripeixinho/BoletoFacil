using BoletoFacil.Domain.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Common;

public class RemessaConfiguration : IEntityTypeConfiguration<Remessa>
{
    public void Configure(EntityTypeBuilder<Remessa> builder)
    {
        builder.ToTable("Remessas");

        builder.HasKey(r => r.RemessaId);

        builder.Property(r => r.ArquivoTXT).IsRequired().HasMaxLength(-1); // indica que não tem tamanho máximo

        builder.HasOne(r => r.DimBanco)
               .WithMany() 
               .HasForeignKey(r => r.BancoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}