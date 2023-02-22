using Domain.OperationResult;

namespace Application.HandlerContracts;

public interface ICommandHandler<TCommand>
{
    Task<Result> Handle(TCommand command);
}
