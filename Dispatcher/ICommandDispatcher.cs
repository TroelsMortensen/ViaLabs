using Domain.OperationResult;

namespace Dispatcher;

public interface ICommandDispatcher
{
    Task<Result> Dispatch<TCommand>(TCommand command) where TCommand : class;
}