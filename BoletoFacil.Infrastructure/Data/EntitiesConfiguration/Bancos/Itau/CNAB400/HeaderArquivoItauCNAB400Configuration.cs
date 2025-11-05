using BoletoFacil.Domain.Core.Entities.Bancos.Itau.CNAB400;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Bancos.Itau.CNAB400;

public class HeaderArquivoItauCNAB400Configuration : IEntityTypeConfiguration<HeaderArquivoItauCNAB400>
{
    public void Configure(EntityTypeBuilder<HeaderArquivoItauCNAB400> builder)
    {
        builder.ToTable("HeaderArquivoItauCNAB400");

        builder.HasKey(x => x.HeaderId);

        builder.Property(x => x.CodigoBanco).IsRequired().HasMaxLength(3);
        builder.Property(x => x.Agencia).IsRequired().HasMaxLength(4);
        builder.Property(x => x.Conta).IsRequired().HasMaxLength(5);
        builder.Property(x => x.DAC).IsRequired().HasMaxLength(1);
        builder.Property(x => x.NomeEmpresa).IsRequired().HasMaxLength(30);
    }
}