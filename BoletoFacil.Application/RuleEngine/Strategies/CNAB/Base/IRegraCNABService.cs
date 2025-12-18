using BoletoFacil.Application.DTOs.Common;

namespace BoletoFacil.Application.RuleEngine.Strategies.CNAB.Base;

public interface IRegraCNABService
{
    void Aplicar(RemessaDTO remessa);
    void GerarNumeroSequencialArquivo (RemessaDTO remessa);
    string GerarUsoEmpresa(string sequencial);
    string GerarNumeroDocumento(string numeroSequencial);
    string? GerarPrazoDias(string instrucao1, string instrucao2, string prazoDias);
}
