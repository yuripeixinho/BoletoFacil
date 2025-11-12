using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Repositories;

namespace BoletoFacil.Application.Validation.Business;

public class RemessaBusinessValidator : IRemessaBusinessValidator
{
    private readonly IRemessaRepository _remessaRepository;  

    public RemessaBusinessValidator()
    {
        
    }

    public Task ValidarGeracaoRemessaAsync(RemessaDTO remessaDTO)
    {
        throw new NotImplementedException();
    }
}
