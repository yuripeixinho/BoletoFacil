using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BoletoFacil.Api.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BoletoFácil API",
                Version = "v1",
                Description = @"
                API responsável pela geração de arquivos de cobrança bancária
                nos padrões CNAB 240 e CNAB 400.

                Fluxo principal:
                1. Recebe dados estruturados baseado no layout das planilhas
                2. Identifica banco e layout via Factory
                3. Aplica regras específicas via Strategy
                4. Gera arquivo CNAB
                5. Persiste informações da remessa

                Planilhas de Teste:

                A API disponibiliza planilhas base para facilitar testes locais a partir dos respectivos endpoints:

                - Itaú CNAB 400: /api/Remessa/excel/templates/itau-cnab400

                Essas planilhas seguem os layouts esperados pela API.
                ",

                Contact = new OpenApiContact
                {
                    Name = "Yuri Peixinho",
                    Url = new Uri("https://github.com/yuripeixinho/BoletoFacil/tree/main")
                }
            });
        });

        return services;
    }
}
