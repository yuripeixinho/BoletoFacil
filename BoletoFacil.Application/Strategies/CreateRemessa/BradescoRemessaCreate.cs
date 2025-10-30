using BoletoFacil.Application.DTOs;

namespace BoletoFacil.Application.Strategies.CreateRemessa;

public class BradescoRemessaCreate : IRemessaCreate
{
    public string GerarRemessa(RemessaDTO remessa)
    {
        return $"REMESSA BRADESCO - {remessa.Banco}";
    }
}
