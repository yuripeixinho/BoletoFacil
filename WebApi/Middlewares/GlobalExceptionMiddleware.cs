using BoletoFacil.Application.Exceptions;
using BoletoFacil.Domain.Core.Exceptions;
using BoletoFacil.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        var (statusCode, title, detail) = exception switch
        {
            ValidationException ve => (422, "Validation error", string.Join("; ", ve.Errors)),

            BusinessRuleException => (400, "Business rule violation", exception.Message),
            DomainException => (400, "Business rule violation", exception.Message),

            NotFoundException => (404, "Not found", exception.Message),
            UnauthorizedException => (401, "Unauthorized", exception.Message),

            DatabaseException => (500, "Database error", "An unexpected database error occurred."),
            ExternalServiceException => (503, "External service error", "Unable to process data from external service."),

            _ => (500, "Server error", "An unexpected error occurred.")
        };

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsJsonAsync(problem);
    }
}
