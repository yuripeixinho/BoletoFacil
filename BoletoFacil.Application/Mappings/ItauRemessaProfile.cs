using AutoMapper;
using BoletoFacil.Application.DTOs.BoundedContexts.Itau.CNAB400;
using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.Mappings;

public class ItauRemessaProfile : Profile
{
    public ItauRemessaProfile()
    {
        CreateMap<HeaderDTO, ItauHeader400DTO>();
        CreateMap<DetalhesDTO, ItauDetalhe400DTO>();
        CreateMap<TrailerDTO, ItauTrailer400DTO>();
    }
}
