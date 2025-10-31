//using BoletoFacil.Application.DTOs;
//using BoletoFacil.Application.DTOs.Layout;
//using BoletoFacil.Application.Interfaces;
//using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts;
//using System.Text;

//namespace BoletoFacil.Application.Strategies.CreateRemessa;

//public abstract class RemessaCreateBase : IRemessaService
//{
//    public async Task<string> GerarRemessaExcelAsync(IFormFile excel)
//    {
//        var layout = await CarregarLayoutAsync();
//        var dados = await LerPlanilhaAsync(excel);
//        var header = GerarLinha(layout.Header, dados);
//        return header;
//    }

//    protected abstract Task<LayoutCnab> CarregarLayoutAsync();

//    protected virtual async Task<Dictionary<int, string[]>> LerPlanilhaAsync(IFormFile excel)
//    {
//        // lê excel e retorna dados por linha
//    }

//    protected string GerarLinha(List<CampoLayout> campos, Dictionary<int, string[]> planilha)
//    {
//        var sb = new StringBuilder(new string(' ', 400));
//        foreach (var campo in campos)
//        {
//            string valor = campo.Valor ?? "";

//            if (campo.Fonte == "planilha" && campo.Coluna.HasValue)
//                valor = planilha[2][campo.Coluna.Value - 1]; // linha 2 como exemplo

//            if (campo.Formato == "ddMMyyyy" && DateTime.TryParse(valor, out var data))
//                valor = data.ToString("ddMMyyyy");

//            valor = valor.Length > campo.Tamanho
//                ? valor[..campo.Tamanho]
//                : valor.PadRight(campo.Tamanho, campo.Preenchimento);

//            sb.Remove(campo.Inicio - 1, campo.Tamanho);
//            sb.Insert(campo.Inicio - 1, valor);
//        }

//        return sb.ToString();
//    }

//    public Task<string> GenerateRemessaAsync(RemessaDTO remessa)
//    {
//        throw new NotImplementedException();
//    }
//}
