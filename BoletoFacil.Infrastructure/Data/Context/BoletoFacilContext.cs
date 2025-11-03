using BoletoFacil.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoFacil.Infrastructure.Data.Context;

public class BoletoFacilContext : DbContext
{
    public BoletoFacilContext(DbContextOptions<BoletoFacilContext> options) : base(options)
    {}

    public DbSet<Remessa> Remessas { get; set; }
    public DbSet<Cedente> Cedentes { get; set; }
    public DbSet<CedenteConta> CedentesConta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoletoFacilContext).Assembly);
    }
}

