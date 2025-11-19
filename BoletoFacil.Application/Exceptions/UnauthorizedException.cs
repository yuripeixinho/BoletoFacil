namespace BoletoFacil.Application.Exceptions;

public class UnauthorizedException : ApplicationExceptionBase
{
    public UnauthorizedException(string message) : base(message){}
}
