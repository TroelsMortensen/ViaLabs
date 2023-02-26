using Domain.OperationResult;

namespace Dispatcher;

public interface ICommandDispatcher
{
    Task<Result> DispatchAsync<TCommand>(TCommand command) where TCommand : class;
}