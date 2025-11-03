using BoletoFacil.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration;


public class CedenteConfiguration : IEntityTypeConfiguration<Cedente>
{
    public void Configure(EntityTypeBuilder<Cedente> builder)
    {
        builder.ToTable("Cedentes");

        builder.HasKey(c => c.CedenteID);
        builder.Property(c => c.NomeEmpresa).HasMaxLength(30).IsRequired();
        builder.Property(c => c.TipoInscricao).HasMaxLength(1).IsRequired();
        builder.Property(c => c.Inscricao).HasMaxLength(14).IsRequired();

        builder.HasOne(c => c.CedenteConta)
            .WithOne(c => c.Cedente)
            .HasForeignKey<Cedente>(cc => cc.CedenteContaID) // <<-- a FK está em CedenteConta
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Cedentes_Conta");
    }
}
