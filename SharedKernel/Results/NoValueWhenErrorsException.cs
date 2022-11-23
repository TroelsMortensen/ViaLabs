namespace SharedKernel.Results;

public class NoValueWhenErrorsException : Exception
{
    public NoValueWhenErrorsException() : base("Catastrophic server error")
    {
    }
}