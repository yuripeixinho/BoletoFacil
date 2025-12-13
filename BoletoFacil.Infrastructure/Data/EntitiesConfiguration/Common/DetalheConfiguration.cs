using BoletoFacil.Domain.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Common;

public class DetalheConfiguration : IEntityTypeConfiguration<Detalhe>
{
    public void Configure(EntityTypeBuilder<Detalhe> builder)
    {
        builder.ToTable("Detalhes");

        builder.HasKey(d => d.DetalheId);

        builder.HasOne(d => d.DimCodigoInscricao)
               .WithMany()
               .HasForeignKey(r => r.CodigoInscricaoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(h => h.Agencia).IsRequired().HasMaxLength(4);
        builder.Property(h => h.Conta).IsRequired().HasMaxLength(5);
        builder.Property(h => h.DAC).IsRequired().HasMaxLength(1);

        builder.Property(h => h.InstrucaoCancelamento).IsRequired().HasMaxLength(4);
        builder.Property(h => h.UsoEmpresa).HasMaxLength(25);
        builder.Property(h => h.NossoNumero).IsRequired().HasMaxLength(8);
    }
}
