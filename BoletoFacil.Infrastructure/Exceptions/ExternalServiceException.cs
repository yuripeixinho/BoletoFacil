namespace BoletoFacil.Infrastructure.Exceptions;

public class ExternalServiceException : Exception
{
    public ExternalServiceException(string message, Exception inner): base(message, inner) { }
}
