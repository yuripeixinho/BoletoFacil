using AutoMapper;
using BoletoFacil.Application.DTOs.Common;
using BoletoFacil.Domain.Core.Entities.Common;
using System.Globalization;

namespace BoletoFacil.Application.Mappings.Common;

public class RemessaProfile : Profile
{
    public RemessaProfile()
    {
        // Mapeamento auxiliar
        CreateMap<HeaderDTO, Header>();
        //CreateMap<DetalhesDTO, Detalhe>()
        //        .ForMember(
        //            dest => dest.ValorCobranca,
        //            opt => opt.MapFrom(src =>
        //                Math.Round(
        //                    decimal.Parse(src.ValorCobranca, CultureInfo.GetCultureInfo("pt-BR")),
        //                    2,
        //                    MidpointRounding.AwayFromZero
        //                )
        //            )
        //        ).ForMember(
        //            dest => dest.ValorCobranca,
        //            opt => opt.MapFrom(src =>
        //                Math.Round(
        //                    decimal.Parse(src.ValorCobranca, CultureInfo.GetCultureInfo("pt-BR")),
        //                    2,
        //                    MidpointRounding.AwayFromZero
        //                )
        //            )
        //        );
    }
}
