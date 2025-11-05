using BoletoFacil.Application.Factories;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Application.Interfaces.Services;
using BoletoFacil.Application.Services;
using BoletoFacil.Application.Strategies.CreateRemessa;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil;
using BoletoFacil.Infrastructure.Data.Context;
using BoletoFacil.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoFacil.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BoletoFacilContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BoletoFacilContext).Assembly.FullName)
            );
        });

        // Repositories
        services.AddScoped<IExcelRepository, ExcelRepository>();

        // Services
        services.AddScoped<IRemessaService, RemessaService>();
        services.AddScoped<IArquivoService, ArquivoService>();

        // Factories
        services.AddScoped<IRemessaFactory, RemessaFactory>();

        // Strategies
        services.AddScoped<IRemessaGenerator, BancoDoBrasilRemessaGenerator>();

        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("BoletoFacil.Application"))
        );

        return services;
    }
}
