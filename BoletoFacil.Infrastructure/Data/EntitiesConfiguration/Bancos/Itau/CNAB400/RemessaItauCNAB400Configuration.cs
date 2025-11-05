using BoletoFacil.Domain.Core.Entities.Bancos.Itau.CNAB400;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Bancos.Itau.CNAB400;

public class RemessaItauCNAB400Configuration : IEntityTypeConfiguration<RemessaItauCNAB400>
{
    public void Configure(EntityTypeBuilder<RemessaItauCNAB400> builder)
    {
        builder.ToTable("RemessaItauCNAB400");

        builder.HasKey(x => x.RemessaId);

        builder.Property(x => x.DataGeracao)
               .IsRequired();

        builder.HasOne(x => x.HeaderArquivo)
               .WithOne()
               .HasForeignKey<RemessaItauCNAB400>(x => x.HeaderId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}