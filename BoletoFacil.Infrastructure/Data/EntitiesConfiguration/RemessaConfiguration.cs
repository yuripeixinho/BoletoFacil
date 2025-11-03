using BoletoFacil.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration;

public class RemessaConfiguration : IEntityTypeConfiguration<Remessa>
{
    public void Configure(EntityTypeBuilder<Remessa> builder)
    {
        // Nome da tabela
        builder.ToTable("Remessas");

        // Chave primária (assumindo propriedade Id no Entity base)
        builder.HasKey(r => r.Id);

        // Colunas e constraints
        builder.Property(r => r.Id)
               .HasColumnName("RemessaId");

        // ForeignKey para CedenteConta
        builder.Property(r => r.CedenteContaId)
               .IsRequired()
               .HasColumnName("CedenteContaId");

        // NumeroSequencialArquivo (armazenar como int; formatação para 6 dígitos é feita na geração)
        builder.Property(r => r.NumeroSequencialArquivo)
               .IsRequired()
               .HasColumnName("NumeroSequencialArquivo");

        // NomeArquivo (opcional)
        builder.Property(r => r.NomeArquivo)
               .HasMaxLength(200)
               .IsUnicode(true)
               .HasColumnName("NomeArquivo");

        // DataGeracao com default no banco
        builder.Property(r => r.DataGeracao)
               .HasColumnType("datetime2")
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .IsRequired()
               .HasColumnName("DataGeracao");

        builder.HasOne(r => r.CedenteConta)
                .WithOne(c => c.Remessa)
                .HasForeignKey<Remessa>(r => r.CedenteContaId) // FK em Remessa
                .OnDelete(DeleteBehavior.Restrict)         // evita cascade delete
                .HasConstraintName("FK_Remessas_CedenteContas");

        // garante unicidade do FK -> garante 1:1 (um CedenteConta só pode estar em uma Remessa)
        builder.HasIndex(r => r.CedenteContaId)
               .IsUnique()
               .HasDatabaseName("UX_Remessas_CedenteContaId_Unique");
    }
}
