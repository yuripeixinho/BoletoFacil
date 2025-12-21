using BoletoFacil.Domain.Core.Entities.Dimension;
using Microsoft.EntityFrameworkCore;

namespace BoletoFacil.Infrastructure.Data.Seeds.Dimensions;

public static class DimBancoSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimBanco>().HasData(
            new DimBanco
            {
                BancoId = 1,
                Nome = "Banco do Brasil",
                RazaoSocial = "Banco do Brasil S.A."
            },
            new DimBanco
            {
                BancoId = 237,
                Nome = "Bradesco",
                RazaoSocial = "Banco Bradesco S.A."
            },
            new DimBanco
            {
                BancoId = 341,
                Nome = "Itaú",
                RazaoSocial = "Itaú Unibanco S.A."
            }
        );
    }
}
