using AutoMapper;
using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Domain.Core.Entities.Common;

namespace BoletoFacil.Application.Mappings;

public class ItauRemessaProfile : Profile
{
    public ItauRemessaProfile()
    {
        CreateMap<HeaderDTO, ItauHeader400DTO>();
        //CreateMap<ConfiguracaoRemessaDTO, Remessa>();
    }

}
