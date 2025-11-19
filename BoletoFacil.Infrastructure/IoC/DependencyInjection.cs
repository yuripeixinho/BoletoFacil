using BoletoFacil.Application.Factories;
using BoletoFacil.Application.Factories.Interfaces;
using BoletoFacil.Application.Interfaces.Repositories;
using BoletoFacil.Application.Interfaces.Services;
using BoletoFacil.Application.Mappings;
using BoletoFacil.Application.Mappings.Common;
using BoletoFacil.Application.Services;
using BoletoFacil.Application.Strategies.CreateRemessa;
using BoletoFacil.Application.Strategies.CreateRemessa.BoundedContexts.BancoDoBrasil;
using BoletoFacil.Application.Validation.Behaviors;
using BoletoFacil.Application.Validation.Business;
using BoletoFacil.Application.Validation.Services;
using BoletoFacil.Infrastructure.Data.Context;
using BoletoFacil.Infrastructure.Data.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
        services.AddScoped<IRemessaRepository, RemessaRepository>();
        services.AddScoped<IBancoRepository, BancoRepository>();

        // Services
        services.AddScoped<IRemessaService, RemessaService>();
        services.AddScoped<IArquivoService, ArquivoService>();
        services.AddScoped<IValidationRemessaService, ValidationRemessaService>();
        services.AddScoped<IUsoEmpresaService, UsoEmpresaService>();

        // Services Validations
        services.AddScoped<IRemessaBusinessValidator, RemessaBusinessValidator>();

        // Factories
        services.AddScoped<IRemessaFactory, RemessaFactory>();

        // Strategies
        services.AddScoped<IRemessaGenerator, BancoDoBrasilRemessaGenerator>();

        // FluentValidation
        services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("BoletoFacil.Application"));

        // Automapper
        services.AddAutoMapper(typeof(RemessaProfile));
        services.AddAutoMapper(typeof(ItauRemessaProfile));

        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("BoletoFacil.Application"))
        );

        // Pipeline Behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
