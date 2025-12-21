using BoletoFacil.Domain.Core.Entities.Dimension;
using BoletoFacil.Domain.Core.Exceptions;

namespace BoletoFacil.Domain.Core.Entities.Common;

public class Remessa
{
    public Guid RemessaId { get; private set; }
    public DimBanco? DimBanco { get; private set; }
    public int BancoId { get; private set; }

    public Header? Header { get; private set; }


    private readonly List<Detalhe> _detalhes = new();
    public IReadOnlyCollection<Detalhe> Detalhes => _detalhes;

    public string? ArquivoTXT { get; private set; }

    // Necessário para EF Core
    // Nunca usado pela aplicação
    // Mantém o domínio seguro
    protected Remessa() { } // EF

    public Remessa(int bancoId, Header header, List<Detalhe> detalhes)
    {
        if (bancoId <= 0)
            throw new DomainException("Banco inválido.");

        Header = header ?? throw new DomainException("Header é obrigatório.");

        if (detalhes is null || !detalhes.Any())
            throw new DomainException("A remessa deve conter ao menos um detalhe.");

        BancoId = bancoId;
        RemessaId = Guid.NewGuid();
        _detalhes.AddRange(detalhes);

        ValidarDominio();
    }

    public void ValidarDominio()
    {
        if (BancoId <= 0)
            throw new DomainException("Não é possível gerar uma remessa sem um banco associado válido.");

        if (Header is null)
            throw new DomainException("Cada remessa deve possuir um header vinculado.");

        if (!Detalhes.Any())
            throw new DomainException("Cada remessa deve possuir pelo menos uma informação de detalhe vinculado.");

        Header.ValidarDominio();
        Detalhes.ToList().ForEach(d => d.ValidarDominio());
        Detalhes.ToList().ForEach(d => d.ValidarDesconto(d.ValorDesconto));    
    }

    public void ArmazenarCNAB(string arquivoTxt)
    {
        if (string.IsNullOrWhiteSpace(arquivoTxt))
            throw new DomainException("Não é possível armazenar um arquivo CNAB vazio.");

        ArquivoTXT = arquivoTxt;
    }
}
