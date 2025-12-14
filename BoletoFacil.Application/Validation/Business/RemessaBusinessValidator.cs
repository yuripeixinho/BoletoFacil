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

        ValidarDetalhes(remessaDTO.DetalhesDTO);
    }

    public void ValidarDetalhes(List<DetalhesDTO> detalhes)
    {
        foreach (var detalhe in detalhes)
        {
            if (detalhe.DataDesconto >= detalhe.DataVencimento)
                throw new BusinessRuleException("A data de vencimento está com o perído inferior ao vencimento.");
        }
    }
}
