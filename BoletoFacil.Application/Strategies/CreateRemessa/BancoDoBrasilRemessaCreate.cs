using BoletoFacil.Application.DTOs;

namespace BoletoFacil.Application.Strategies.CreateRemessa;

public class BancoDoBrasilRemessaCreate : IRemessaCreate
{
    public string GerarRemessa(RemessaDTO remessa)
    {
        return $"REMESSA BANCO DO BRASIL - {remessa.Banco}";
    }
}
