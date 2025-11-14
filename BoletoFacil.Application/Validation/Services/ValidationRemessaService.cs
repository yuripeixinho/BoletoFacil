using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Interfaces.Services;
using FluentValidation;

namespace BoletoFacil.Application.Validation.Services;

public class ValidationRemessaService : IValidationRemessaService
{
    private readonly IValidator<RemessaDTO> _remessaValidator;

    public ValidationRemessaService(IValidator<RemessaDTO> remessaValidator)
    {
        _remessaValidator = remessaValidator;
    }

    public async Task ValidarAsync(RemessaDTO remessaDTO)
    {
        if (remessaDTO is null)
            throw new ValidationException("Os dados da remessa não podem ser nulos.");

        var result = await _remessaValidator.ValidateAsync(remessaDTO);

        if (!result.IsValid)
        {
            var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Erros de validação encontrados: {erros}");
        }
    }
}

