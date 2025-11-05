using BoletoFacil.Domain.Core.Entities.Bancos.Itau.CNAB400;
using Microsoft.EntityFrameworkCore;

namespace BoletoFacil.Infrastructure.Data.Context;

public class BoletoFacilContext : DbContext
{
    public BoletoFacilContext(DbContextOptions<BoletoFacilContext> options) : base(options)
    {}

    public DbSet<RemessaItauCNAB400> ItauRemessas { get; set; }
    public DbSet<HeaderArquivoItauCNAB400> ItauHeaderArquivo400 { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoletoFacilContext).Assembly);
    }
}

