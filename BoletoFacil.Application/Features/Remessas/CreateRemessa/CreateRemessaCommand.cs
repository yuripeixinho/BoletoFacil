using BoletoFacil.Application.DTOs;
using MediatR;

namespace BoletoFacil.Application.Features.Remessas.CreateRemessa;

public record CreateRemessaCommand(LeituraExcelDTO ExcelRemessa) : IRequest<string>;

