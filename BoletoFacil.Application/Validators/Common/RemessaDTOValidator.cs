using BoletoFacil.Application.DTOs.Common;
using FluentValidation;

namespace BoletoFacil.Application.Validators.Common;

public class RemessaDTOValidator : AbstractValidator<RemessaDTO>
{
    public RemessaDTOValidator()
    {
        //RuleFor(r => r.Banco)
        //    .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Banco"));

        //RuleFor(x => x.Layout)
        //    .NotEmpty().WithMessage(MensagemGenerica.CampoObrigatorio("Layout"));

        //RuleFor(x => x.HeaderDTO)
        //    .NotNull().WithMessage(MensagemGenerica.CampoNaoNulo("Header"))
        //    .SetValidator(new HeaderDTOValidator());
    }
}
