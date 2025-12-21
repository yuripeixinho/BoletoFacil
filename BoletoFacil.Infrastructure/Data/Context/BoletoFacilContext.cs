using BoletoFacil.Domain.Core.Entities.Common;
using BoletoFacil.Domain.Core.Entities.Dimension;
using BoletoFacil.Infrastructure.Data.Seeds.Dimensions;
using Microsoft.EntityFrameworkCore;

namespace BoletoFacil.Infrastructure.Data.Context;

public class BoletoFacilContext : DbContext
{
    public BoletoFacilContext(DbContextOptions<BoletoFacilContext> options) : base(options)
    { }

    // Tabelas de Regras de Negócios
    public DbSet<Remessa> Remessas { get; set; }
    public DbSet<Header> Headers { get; set; }
    public DbSet<Detalhe> Detalhes { get; set; }

    // Tabelas de Dimensões
    public DbSet<DimBanco> DimBancos { get; set; }
    public DbSet<DimCodigoInscricao> DimCodigoInscricoes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoletoFacilContext).Assembly);

        DimBancoSeed.Seed(modelBuilder);
        DimCodigoInscricaoSeed.Seed(modelBuilder);

    }
}

