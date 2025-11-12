using FluentValidation;

namespace BoletoFacil.Application.Features.Remessas.CreateRemessa;

public class CreateRemessaValidator : AbstractValidator<CreateRemessaCommand>
{
    public CreateRemessaValidator()
    {
        RuleFor(x => x.ExcelRemessaDTO)
            .NotNull().WithMessage("O arquivo excel é obrigatório");
    
        RuleFor(x => x.ExcelRemessaDTO.LayoutExcel)
            .Must(file => file.Length > 0).WithMessage("O arquivo Excel está vazio.");

        RuleFor(x => x.ExcelRemessaDTO.LayoutExcel.FileName)
            .Must(fileName => fileName.EndsWith(".xlsx") || fileName.EndsWith(".xls"))
            .WithMessage("O arquivo deve ser um Excel válido (.xlsx ou .xls).");
    }
}