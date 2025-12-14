using BoletoFacil.Application.Exceptions;
using BoletoFacil.Domain.Core.Exceptions;
using BoletoFacil.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BoletoFacil.Api.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try 
        {
            await _next(context);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problem = exception switch
        {
            FluentValidation.ValidationException ve => CriarProblemaValidacao(context, ve),

            BusinessRuleException => CriarProblema(context, 400, "Business rule violation", exception.Message),
            DomainException => CriarProblema(context, 400, "Business rule violation", exception.Message),

            NotFoundException => CriarProblema(context, 404, "Not found", exception.Message),
            UnauthorizedException => CriarProblema(context, 401, "Unauthorized", exception.Message),

            DatabaseException => CriarProblema(context, 500, "Database error", "An unexpected database error occurred."),
            ExternalServiceException => CriarProblema(context, 503, "External service error", "Unable to process data from external service."),

            _ => CriarProblema(context, 500, "Server error", "An unexpected error occurred.")
        };


        context.Response.StatusCode = problem.Status!.Value;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsJsonAsync(problem);
    }

    private static ProblemDetails CriarProblema(
    HttpContext context,
    int statusCode,
    string title,
    string detail)
    {
        return new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = context.Request.Path
        };
    }

    private static ProblemDetails CriarProblemaValidacao(
    HttpContext context,
    FluentValidation.ValidationException exception)
    {

        var problem = new ProblemDetails
        {
            Status = 422,
            Title = "Validation error",
            Type = "https://httpstatuses.com/422",
            Instance = context.Request.Path
        };

        problem.Extensions["errors"] = exception.Errors
        .GroupBy(e => e.PropertyName.Split('.').Last())
        .ToDictionary(
            g => g.Key,
            g => g.Select(e => e.ErrorMessage).ToArray()
        );


        return problem;
    }

}
