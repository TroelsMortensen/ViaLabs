using Application.HandlerContracts;
using Dispatcher.Exceptions;
using Domain.OperationResult;

namespace Dispatcher.DispatcherImplementations;

public class CommandDispatcherWithServiceProvider : ICommandDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public CommandDispatcherWithServiceProvider(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    
    public Task<Result> Dispatch<TCommand>(TCommand command) where TCommand : class
    {
        // get type of this interface
        Type handlerInterfaceType = typeof(ICommandHandler<>);

        // get the type of the interface, now with the command type as generic type parameter
        Type handlerInterfaceWithCommandType = handlerInterfaceType.MakeGenericType(command.GetType());

        ICommandHandler<TCommand>? commandHandler =
            serviceProvider.GetService(handlerInterfaceWithCommandType) as ICommandHandler<TCommand>;
        
        if (commandHandler == null)
        {
            throw new CommandDispatcherException($"Unable to find instance of {handlerInterfaceWithCommandType}");
        }

        return commandHandler.Handle(command);
    }
}