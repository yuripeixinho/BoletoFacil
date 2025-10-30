using BoletoFacil.Application.Factories;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces;
using BoletoFacil.Application.Services;
using BoletoFacil.Application.Strategies.CreateRemessa;
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
        services.AddScoped<IRemessaCreate, BancoDoBrasilRemessaCreate>();
        services.AddScoped<IRemessaCreate, BradescoRemessaCreate>();

        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("BoletoFacil.Application"))
        );

        return services;
    }
}
