using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Validation.Messages;
using FluentValidation;

namespace BoletoFacil.Application.Validation.DTO;

public class DetalheDTOValidator : AbstractValidator<DetalhesDTO?>
{
    public DetalheDTOValidator()
    {
        RuleFor(x => x.DataVencimento)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Data Vencimento"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Data Vencimento"))
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Data de vencimento inválida");

        RuleFor(x => x!.ValorCobranca)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Valor Cobrança"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Valor Cobrança"))
            .Must(SerValorMaiorQueZero).WithMessage("O valor de cobrança deve ser mais que zero.");

        RuleFor(x => x!.EspecieTitulo)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Espécie do Título"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Espécie do Título"))
            .MaximumLength(2)
            .Must(x => int.Parse(x) > 0).WithMessage("Espécie do Título deve ser maior que zero");

        RuleFor(x => x!.Instrucao1)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Instrução 1"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Instrução 1"))
            .MaximumLength(2).WithMessage(MensagemGenerica.TamanhoMaximo("Instrução 1", 2));

        RuleFor(x => x!.Instrucao2)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Instrução 2"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Instrução 2"))
            .MaximumLength(2).WithMessage(MensagemGenerica.TamanhoMaximo("Instrução 2", 2));

        RuleFor(x => x!.ValorCobranca)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Valor de Desconto"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Valor de Desconto"));

        RuleFor(x => x!.CodigoInscricaoPagador)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Código de Inscrição"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Código de Inscrição"))
            .MaximumLength(2).WithMessage(MensagemGenerica.TamanhoMaximo("Código de Inscrição", 2));

        RuleFor(x => x!.NumeroInscricao)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Número de Inscrição"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Número de Inscrição"))
            .MinimumLength(11).WithMessage(MensagemGenerica.TamanhoEntre("Número de Inscrição", 11, 14))
            .MaximumLength(14).WithMessage(MensagemGenerica.TamanhoEntre("Número de Inscrição", 11, 14));

        RuleFor(x => x!.Nome)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Nome"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Nome"))
            .MaximumLength(30).WithMessage(MensagemGenerica.TamanhoMaximo("Nome", 30));

        RuleFor(x => x!.Logradouro)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Logradouro"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Logradouro"))
            .MaximumLength(40).WithMessage(MensagemGenerica.TamanhoMaximo("Logradouro", 40));

        RuleFor(x => x!.Bairro)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Bairro"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Bairro"))
            .MaximumLength(12).WithMessage(MensagemGenerica.TamanhoExato("Bairro", 12));

        RuleFor(x => x!.CEP)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("CEP"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("CEP"))
            .Length(8).WithMessage("O CEP deve conter exatamente 8 caracteres.")
            .Matches(@"^\d{8}$").WithMessage("O CEP deve conter apenas números.");

        RuleFor(x => x!.Cidade)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Cidade"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Cidade"))
            .MaximumLength(12).WithMessage(MensagemGenerica.TamanhoMaximo("Cidade", 12));

        RuleFor(x => x!.Estado)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Estado"))
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Estado"))
            .MaximumLength(2).WithMessage(MensagemGenerica.TamanhoMaximo("Estado", 2));

        RuleFor(x => x!.PrazoDias)
            .MaximumLength(2).WithMessage(MensagemGenerica.TamanhoMaximo("Prazo de Dias", 2));
    }

    private bool SerValorMaiorQueZero(decimal valor)
    {
        if (valor <= 0)
            return false;

        return true;
    }
}
