using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BoletoFacil.Infrastructure.Data.Repositories;

public class BancoRepository : IBancoRepository
{
    private readonly BoletoFacilContext _context;

    public BancoRepository(BoletoFacilContext context)
    {
        _context = context; 
    }

    public async Task<bool> ExistsAsync(string codigoBanco)
    {
        var banco = await _context.DimBancos
            .AnyAsync(b => b.BancoId.ToString() == codigoBanco);

        return banco;
    }
}
