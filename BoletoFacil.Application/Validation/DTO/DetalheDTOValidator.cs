using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Validation.Messages;
using FluentValidation;
using System.Globalization;

namespace BoletoFacil.Application.Validation.DTO;

public class DetalheDTOValidator : AbstractValidator<DetalhesDTO?>
{
    public DetalheDTOValidator()
    {
        RuleFor(x => x!.DataVencimento)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Data Vencimento"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Data Vencimento"))
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Data de vencimento inválida");

        RuleFor(x => x!.ValorCobranca)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Data Vencimento"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Data Vencimento"))
            .Must(SerValorMaiorQueZero).WithMessage("O valor de cobrança deve ser mais que zero.");

        RuleFor(x => x!.EspecieTitulo)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Espécie do Título"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Espécie do Título"))
            .MaximumLength(2);

        RuleFor(x => x!.Instrucao1)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Instrução 1"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Instrução 1"))
            .MaximumLength(2);

        RuleFor(x => x!.Instrucao2)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Instrução 2"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Instrução 2"))
            .MaximumLength(2);
    }

    private bool SerValorMaiorQueZero(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            return false;

        // aceita 10.50 e 10,50
        return decimal.TryParse(
            valor,
            NumberStyles.Number,
            CultureInfo.GetCultureInfo("pt-BR"),
            out var valorDecimal)
            && valorDecimal > 0;
    }


}
