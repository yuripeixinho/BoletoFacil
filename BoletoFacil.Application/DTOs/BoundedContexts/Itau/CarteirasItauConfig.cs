using BoletoFacil.Application.Enum;

namespace BoletoFacil.Application.DTOs.BoundedContexts.Itau;

public static class CarteirasItauConfig
{
    // Carteiras que NÃO geram Nosso Número (escriturais)
    public static readonly CarteiraItau[] CarteirasNaoGeramNossoNumero =
    [
        CarteiraItau.C107,
        CarteiraItau.C122,
        CarteiraItau.C131,
        CarteiraItau.C146,
        CarteiraItau.C150,
        CarteiraItau.C168,
        CarteiraItau.C169,
        CarteiraItau.C180,
        CarteiraItau.C191,
    ];

    // Carteiras que GERAM Nosso Número (sem registro / diretas)
    public static readonly CarteiraItau[] CarteirasGeramNossoNumero =
    [
        CarteiraItau.C104,
        CarteiraItau.C109,
        CarteiraItau.C112,
        CarteiraItau.C115,
        CarteiraItau.C121,
        CarteiraItau.C123,
        CarteiraItau.C126,
        CarteiraItau.C138,
        CarteiraItau.C147,
        CarteiraItau.C157,
        CarteiraItau.C174,
        CarteiraItau.C175,
        CarteiraItau.C178,
        CarteiraItau.C188,
        CarteiraItau.C195,
        CarteiraItau.C196,
    ];

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