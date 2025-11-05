using BoletoFacil.Application.DTOs.Common;
using MediatR;

namespace BoletoFacil.Application.Features.Remessas.CreateRemessa;

public record CreateRemessaCommand(LeituraExcelDTO ExcelRemessa) : IRequest<string>;

