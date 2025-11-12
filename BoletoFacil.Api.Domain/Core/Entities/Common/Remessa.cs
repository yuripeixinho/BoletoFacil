using BoletoFacil.Domain.Core.Entities.Dimension;
using BoletoFacil.Domain.Core.Exceptions;

namespace BoletoFacil.Domain.Core.Entities.Common;

public class Remessa
{
    public Guid RemessaId { get; private set; }

    public DimBanco? DimBanco { get; private set; }      
    public int BancoId { get; private set; }


    public Header? Header { get; private set; }
    public int HeaderId { get; private set; }

    public string ArquivoTXT { get; private set; }

    private Remessa() { } // usado apenas por EF e AutoMapper

    public Remessa(Guid remessaId, int bancoId, int headerId, string arquivoTxt)
    {
        RemessaId = remessaId;     
        BancoId = bancoId;
        HeaderId = headerId;
        ArquivoTXT = arquivoTxt;

        ValidarDominio();
    }

    public void ValidarDominio()
    {
        if (BancoId <= 0)
            throw new DomainException("Não é possível gerar uma remessa sem um banco associado válido.");

        if (Header is null)
            throw new DomainException("Cada remessa deve possuir um header vinculado.");

        Header.ValidarDominio();

        if (string.IsNullOrWhiteSpace(ArquivoTXT))
            throw new DomainException("Não é possível armazenar uma remessa sem o conteúdo do arquivo CNAB.");
    }

    public void ArmazenarCNAB(string arquivoTxt)
    {
        if (string.IsNullOrWhiteSpace(arquivoTxt))
            throw new DomainException("Não é possível armazenar um arquivo CNAB vazio.");

        ArquivoTXT = arquivoTxt;
    }
}
