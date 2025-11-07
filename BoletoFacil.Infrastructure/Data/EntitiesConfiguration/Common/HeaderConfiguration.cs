using BoletoFacil.Domain.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Bancos.Itau.CNAB400;

public class HeaderItauCNAB400Configuration : IEntityTypeConfiguration<Header>
{
    public void Configure(EntityTypeBuilder<Header> builder)
    {
        builder.ToTable("Headers");

        //builder.HasKey(x => x.HeaderId);

        //builder.Property(x => x.Agencia).IsRequired().HasMaxLength(4);
        //builder.Property(x => x.Conta).IsRequired().HasMaxLength(5);
        //builder.Property(x => x.DAC).IsRequired().HasMaxLength(1);
        //builder.Property(x => x.NomeEmpresa).IsRequired().HasMaxLength(30);

        //builder.HasOne(x => x.Remessa)
        //       .WithOne()
        //       .HasForeignKey<Header>(x => x.RemessaId)
        //       .OnDelete(DeleteBehavior.Restrict);
    }
}