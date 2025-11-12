using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Validation.Business;

public interface IRemessaBusinessValidator
{
    Task ValidarGeracaoRemessaAsync(RemessaDTO remessaDTO);

}
