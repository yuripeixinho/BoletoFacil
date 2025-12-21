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
               .HasForeignKey(d => d.CodigoInscricaoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Remessa)
               .WithMany(r => r.Detalhes)
               .HasForeignKey(d => d.RemessaId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(d => d.Agencia)
               .IsRequired()
               .HasMaxLength(4);

        builder.Property(d => d.Conta)
               .IsRequired()
               .HasMaxLength(5);

        builder.Property(d => d.DAC)
               .IsRequired()
               .HasMaxLength(1);

        builder.Property(d => d.InstrucaoCancelamento)
               .IsRequired()
               .HasMaxLength(4);

        builder.Property(d => d.UsoEmpresa)
               .HasMaxLength(25);

        builder.Property(d => d.NossoNumero)
               .IsRequired()
               .HasMaxLength(8);

        builder.Property(d => d.DataVencimento)
               .IsRequired();

        builder.Property(d => d.ValorCobranca)
               .IsRequired()
               .HasPrecision(15, 2);

        builder.Property(d => d.Instrucao1)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(d => d.Instrucao2)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(d => d.DataDesconto);

        builder.Property(d => d.ValorDesconto)
               .HasPrecision(15, 2);

        builder.Property(d => d.NumeroInscricao)
               .IsRequired()
               .HasMaxLength(14);

        builder.Property(d => d.Nome)
               .IsRequired()
               .HasMaxLength(30);

        builder.Property(d => d.Logradouro)
               .IsRequired()
               .HasMaxLength(40);

        builder.Property(d => d.Bairro)
               .IsRequired()
               .HasMaxLength(12);

        builder.Property(d => d.CEP)
               .IsRequired()
               .HasMaxLength(8);

        builder.Property(d => d.Cidade)
               .IsRequired()
               .HasMaxLength(12);

        builder.Property(d => d.Estado)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(d => d.NomeSacadorAvalista)
               .IsRequired()
               .HasMaxLength(30);
    }
}
