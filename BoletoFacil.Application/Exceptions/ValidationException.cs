namespace BoletoFacil.Application.Exceptions;

public class ValidationException : ApplicationExceptionBase
{
    public IEnumerable<string> Errors { get; }

    public ValidationException(IEnumerable<string> errors)
        : base("Validação falhou") 
    {
        Errors = errors;    
    }
}
