using BoletoFacil.Application.Factories;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces;
using BoletoFacil.Application.Services;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoFacil.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        // Services
        services.AddScoped<IRemessaService, RemessaService>();

        // Factories
        services.AddScoped<IRemessaFactory, RemessaFactory>();

        // Strategies
        services.AddScoped<IRemessaGenerator, BancoDoBrasilRemessaGenerator>();
        services.AddScoped<IRemessaGenerator, BradescoRemessaGenerator>();

        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("BoletoFacil.Application"))
        );

        return services;
    }
}
