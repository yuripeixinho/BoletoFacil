using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Domain.Core.Exceptions;

namespace BoletoFacil.Application.Validation.Business;

public class RemessaBusinessValidator : IRemessaBusinessValidator
{
    private readonly IBancoRepository _bancoRepository;  

    public RemessaBusinessValidator(IBancoRepository bancoRepository)
    {
        _bancoRepository = bancoRepository;
    }

    public async Task ValidarGeracaoRemessaAsync(RemessaDTO remessaDTO)
    {
        if (!await _bancoRepository.ExistsAsync(remessaDTO.Banco))
            throw new BusinessRuleException("O banco informado não existe ou está inativo.");
    }
}
