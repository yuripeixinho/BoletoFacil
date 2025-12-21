using BoletoFacil.Domain.Core.Entities.Dimension;
using Microsoft.EntityFrameworkCore;

namespace BoletoFacil.Infrastructure.Data.Seeds.Dimensions;

public static class DimCodigoInscricaoSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimCodigoInscricao>().HasData(
            new DimCodigoInscricao
            {
                CodigoInscricaoId = 1,
                Nome = "CPF do Beneficiário"
            },
            new DimCodigoInscricao
            {
                CodigoInscricaoId = 2,
                Nome = "CNPJ do Beneficiário"
            },
            new DimCodigoInscricao
            {
                CodigoInscricaoId = 3,
                Nome = "CPF do Sacador/Avalista"
            },
            new DimCodigoInscricao
            {
                CodigoInscricaoId = 4,
                Nome = "CNPJ do Sacador/Avalista"
            }
        );
    }
}
