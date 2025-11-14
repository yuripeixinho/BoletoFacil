namespace BoletoFacil.Application.Validation.Messages;

public static class MensagemGenerica
{
    public static string CampoObrigatorio(string nomeCampo)
            => $"O campo '{nomeCampo}' é obrigatório.";

    public static string CampoNaoNulo(string nomeCampo)
            => $"O campo '{nomeCampo}' não pode ser nulo.";

    public static string TamanhoExato(string nomeCampo, int tamanho)
        => $"O campo '{nomeCampo}' deve conter exatamente {tamanho} caracteres.";

    public static string TamanhoEntre(string nomeCampo, int min, int max)
        => $"O campo '{nomeCampo}' deve ter entre {min} e {max} caracteres.";

    public static string FormatoInvalido(string nomeCampo)
        => $"O campo '{nomeCampo}' está em formato inválido.";

    public static string ValorMaiorQueZero(string nomeCampo)
        => $"O campo '{nomeCampo}' deve ser maior que zero.";

    public static string DataFutura(string nomeCampo)
        => $"O campo '{nomeCampo}' deve conter uma data futura.";
}
