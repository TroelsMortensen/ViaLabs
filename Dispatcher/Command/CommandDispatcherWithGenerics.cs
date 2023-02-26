using System.Reflection;
using Application.HandlerContracts;
using Dispatcher.Exceptions;
using Domain.OperationResult;

namespace Dispatcher.Command;

/**
 * From here
 * https://medium.com/swlh/dynamic-command-dispatching-in-c-d3abe21b3d1b
 *
 * NOT YET ACTUALLY WORKING.
 * TODO missing dynamically creating arguments for my command handler constructors. Someday.
 */
public class CommandDispatcherWithGenerics : ICommandDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public CommandDispatcherWithGenerics(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task<Result> DispatchAsync<TCommand>(TCommand command) where TCommand : class
    {
        // get type of this interface
        Type handlerInterfaceType = typeof(ICommandHandler<>);

        // get the type of the interface, now with the command type as generic type parameter
        Type handlerInterfaceWithCommandType = handlerInterfaceType.MakeGenericType(command.GetType());

        ;
        // find all classes, which implements
        Type[] typesOfImplementingClasses = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && t.GetInterfaces().Contains(handlerInterfaceWithCommandType))
            .ToArray();

        // check for errors
        if (!typesOfImplementingClasses.Any())
            throw new CommandDispatcherException($"Could not find command handler for command of type {command.GetType()}");

        if (typesOfImplementingClasses.Length != 1)
        {
            throw new CommandDispatcherException($"Found too many handlers for {command.GetType()}");
        }

        // invoke command handler
        foreach (Type classType in typesOfImplementingClasses)
        {
            ICommandHandler<TCommand>? commandHandler = Activator.CreateInstance(classType) as ICommandHandler<TCommand>;
            if (commandHandler == null)
            {
                throw new CommandDispatcherException($"Unable to create instance of {classType}");
            }

            Result result = await commandHandler.Handle(command);
            return result;
        }

        throw new CommandDispatcherException("I should never reach this line");
    }

}

