using BoletoFacil.Domain.Core.Entities.Common;

namespace BoletoFacil.Domain.Core.Entities.Bancos.Itau.CNAB400;

public class RemessaItauCNAB400 : RemessaBase
{

    public Guid HeaderId { get; set; }
    public required HeaderArquivoItauCNAB400 HeaderArquivo { get; set; }   
}
