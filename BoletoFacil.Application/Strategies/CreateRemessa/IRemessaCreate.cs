using BoletoFacil.Application.DTOs;

namespace BoletoFacil.Application.Strategies.CreateRemessa;

public interface IRemessaCreate
{
    string GerarRemessa(RemessaDTO remessa);
}
