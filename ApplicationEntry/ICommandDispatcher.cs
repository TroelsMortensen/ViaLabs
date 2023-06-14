using Domain.OperationResult;

namespace ApplicationEntry;

public interface ICommandDispatcher
{
    Task<Result> DispatchAsync<TCommand>(TCommand command) where TCommand : class;
}