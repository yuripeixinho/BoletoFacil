using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Application.Validation.Messages;
using FluentValidation;

namespace BoletoFacil.Application.Validation.DTO;

public class RemessaDTOValidator : AbstractValidator<RemessaDTO>
{
    public RemessaDTOValidator()
    {
        RuleFor(r => r.Banco)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Banco"));

        RuleFor(x => x.Layout)
            .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Layout"));

        RuleFor(x => x.HeaderDTO)
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Header"))
            .SetValidator(new HeaderDTOValidator());

        RuleForEach(x => x.DetalhesDTO)
            .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Detalhe"))
            .SetValidator(new DetalheDTOValidator());
    }
}
