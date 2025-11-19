namespace BoletoFacil.Application.Exceptions;

public class ApplicationExceptionBase : Exception
{
    protected ApplicationExceptionBase(string message) : base(message) { }
}
