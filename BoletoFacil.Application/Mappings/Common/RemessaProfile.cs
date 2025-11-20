using AutoMapper;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Domain.Core.Entities.Common;

namespace BoletoFacil.Application.Mappings.Common;

public class RemessaProfile : Profile
{
    public RemessaProfile()
    {
        CreateMap<RemessaDTO, Remessa>()
                .ForMember(dest => dest.BancoId, opt => opt.MapFrom(src => int.Parse(src.Banco)))
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => src.HeaderDTO))
                .ForMember(dest => dest.ArquivoTXT, opt => opt.Ignore()) // instrui o AutoMapper a não mexer em ArquivoTXT durante o mapeamento. Nesse caso vamos inserir o ArquivoTXT depois que instanciar o automapper no método
                .ForMember(dest => dest.Detalhes, opt => opt.MapFrom(src => src.DetalhesDTO));

        // Mapeamento auxiliar
        CreateMap<HeaderDTO, Header>();
        CreateMap<DetalhesDTO, Detalhe>();
    }
}
