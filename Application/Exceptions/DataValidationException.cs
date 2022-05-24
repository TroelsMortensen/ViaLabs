namespace Application.Exceptions;

public class DataValidationException : Exception
{
    public IEnumerable<string> Errors { get; }

    public DataValidationException(string msg, ICollection<string> errors) : base(msg)
    {
        Errors = errors;
    }
}