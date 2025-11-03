using BoletoFacil.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration;

public class CedenteContaConfiguration : IEntityTypeConfiguration<CedenteConta>
{
    public void Configure(EntityTypeBuilder<CedenteConta> builder)
    {
        builder.ToTable("CedentesContas");

        builder.HasKey(c => c.CedenteContaID);

        builder.Property(c => c.CedenteContaID).HasColumnName("CedenteContaID");
        builder.Property(c => c.CedenteID).HasColumnName("CedenteID").IsRequired();

        builder.Property(c => c.CodigoBanco).HasMaxLength(3).IsRequired();
        builder.Property(c => c.Agencia).HasMaxLength(10).IsRequired();
        builder.Property(c => c.Conta).HasMaxLength(20).IsRequired();
        builder.Property(c => c.Convenio).HasMaxLength(50);

        // RELAÇÃO 1:1 com Cedente (Cedente é principal, CedenteConta é dependente)
        builder.HasOne(cc => cc.Cedente)
               .WithOne(c => c.CedenteConta)
               .HasForeignKey<CedenteConta>(cc => cc.CedenteID) // <<-- a FK está em CedenteConta
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_CedenteContas_Cedentes");

    }
}
