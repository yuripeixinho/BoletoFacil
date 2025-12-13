using BoletoFacil.Application.Enum;

namespace BoletoFacil.Application.DTOs.BoundedContexts.Itau;

public static class CarteirasItauConfig
{
    // Carteiras que NÃO geram Nosso Número (escriturais)
    public static readonly CarteiraItau[] CarteirasNaoGeramNossoNumero =
    [
        CarteiraItau.C104,
        CarteiraItau.C112,
        CarteiraItau.C138,
        CarteiraItau.C147,
    ];

    // Carteiras que GERAM Nosso Número (sem registro / diretas)
    public static readonly CarteiraItau[] CarteirasGeramNossoNumero =
    [
        CarteiraItau.C108,
        CarteiraItau.C173,
        CarteiraItau.C138,
        CarteiraItau.C196,
        CarteiraItau.C103,
    ];

    public static string GerarCodigoCarteira(int carteira)
    {
        if (carteira == (int)CarteiraItau.C147)
            return "E";

        return "I";
    }

    public static bool DevoGerarNossoNumero(string carteiraString)
    {
        if (string.IsNullOrWhiteSpace(carteiraString))
            throw new ArgumentException("Carteira inválida.", nameof(carteiraString));

        if (!int.TryParse(carteiraString, out var numero))
            throw new ArgumentException("Carteira deve ser um número válido.", nameof(carteiraString));

        return DevoGerarNossoNumero((int)numero);
    }

    public static bool DevoGerarNossoNumero(int numeroCarteira)
    {
        var carteira = (CarteiraItau)numeroCarteira;

        // Se estiver na lista de não geram -> retorna false (não gera)
        if (CarteirasNaoGeramNossoNumero.Contains(carteira))
            return false;

        // Se estiver explicitamente em 'geram' -> true
        if (CarteirasGeramNossoNumero.Contains(carteira))
            return true;

        // Default: caso ambíguo, você decide — aqui eu retorno true (gera)
        return true;
    }
}