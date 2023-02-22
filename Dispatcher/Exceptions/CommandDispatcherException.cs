namespace Dispatcher.Exceptions;

public class CommandDispatcherException : Exception
{
    public CommandDispatcherException(string? message) : base(message)
    {
    }
}