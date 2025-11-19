namespace BoletoFacil.Application.Exceptions;

public class NotFoundException : ApplicationExceptionBase
{
    public NotFoundException(string message) : base(message){ }
}
