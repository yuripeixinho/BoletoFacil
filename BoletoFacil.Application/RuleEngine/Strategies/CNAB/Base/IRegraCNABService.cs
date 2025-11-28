using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.RuleEngine.Strategies.CNAB.Base;

public interface IRegraCNABService
{
    void Aplicar(RemessaDTO remessa);
    void GerarNumeroSequencialArquivo (RemessaDTO remessa);
    string GerarUsoEmpresa(string sequencial);
}
