using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Domain.Core.Entities.Common;
using BoletoFacil.Infrastructure.Data.Context;

namespace BoletoFacil.Infrastructure.Data.Repositories;

public class RemessaRepository : IRemessaRepository
{
    private BoletoFacilContext _context;    

    public RemessaRepository(BoletoFacilContext context)
    {
        _context = context; 
    }

    public async Task<Remessa> SalvarRemessaAsync(Remessa remessa)
    {
        _context.Remessas.Add(remessa); 
        await _context.SaveChangesAsync();

        return remessa;
    }
}
