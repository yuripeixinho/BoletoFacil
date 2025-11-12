using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Interfaces.Services;

public interface IValidationRemessaService
{
    Task ValidarAsync(RemessaDTO remessaDTO);
}
