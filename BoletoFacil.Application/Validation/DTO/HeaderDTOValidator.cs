using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Validation.Messages;
using FluentValidation;

namespace BoletoFacil.Application.Validation.DTO;

public class HeaderDTOValidator : AbstractValidator<HeaderDTO?>
{
    public HeaderDTOValidator()
    {
        RuleFor(x => x!.Agencia)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Agencia"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Agencia"))
            .Length(4).WithMessage("A Agência deve ter 4 dígitos.");

        RuleFor(x => x!.Conta)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Conta"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Conta"))
            .Length(5, 10).WithMessage("A Conta deve ter entre 5 e 10 dígitos.");

        RuleFor(x => x!.DAC)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("DAC"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("DAC"))
            .Length(1).WithMessage("O DAC deve ter apenas 1 caractere.");

        RuleFor(x => x!.NomeEmpresa)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("NomeEmpresa"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("NomeEmpresa"))
            .MaximumLength(30).WithMessage("O Nome da Empresa deve ter no máximo 30 caracteres.");
    }
}
