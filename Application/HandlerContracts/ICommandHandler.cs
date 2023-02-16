using Domain.OperationResult;

namespace Application.HandlerContracts;

public interface ICommandHandler<TCommand>
{
    Task<Result> Handle(TCommand command);
}

public interface ICommandHandler<TCommand, TResult>
{
    Task<Result<TResult>> Handle(TCommand command);
}