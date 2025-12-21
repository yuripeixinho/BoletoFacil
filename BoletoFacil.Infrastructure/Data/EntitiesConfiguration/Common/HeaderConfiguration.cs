using BoletoFacil.Domain.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Common;

public class HeaderItauCNAB400Configuration : IEntityTypeConfiguration<Header>
{
    public void Configure(EntityTypeBuilder<Header> builder)
    {
        builder.ToTable("Headers");

        builder.HasKey(h => h.HeaderId);

        builder.HasOne(h => h.Remessa)
           .WithOne(r => r.Header)
           .HasForeignKey<Header>(h => h.RemessaId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Property(h => h.Agencia).IsRequired().HasMaxLength(4);
        builder.Property(h => h.Conta).IsRequired().HasMaxLength(5);
        builder.Property(h => h.DAC).IsRequired().HasMaxLength(1);
        builder.Property(h => h.NomeEmpresa).IsRequired().HasMaxLength(30);
    }
}