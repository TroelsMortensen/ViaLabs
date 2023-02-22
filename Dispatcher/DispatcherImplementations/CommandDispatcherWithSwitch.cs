using Application.HandlerContracts;
using Application.RepositoryContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Application.UseCases.CategoryUseCases.CategoryDelete;
using Application.UseCases.CategoryUseCases.CategoryUpdate;
using Dispatcher.Exceptions;
using Domain.OperationResult;
using Microsoft.Extensions.DependencyInjection;

namespace Dispatcher.DispatcherImplementations;

public class CommandDispatcherWithSwitch : ICommandDispatcher
{

    private readonly IServiceProvider serviceProvider;

    public CommandDispatcherWithSwitch(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<Result> Dispatch<TCommand>(TCommand command) where TCommand : class
    {
        
        switch (command)
        {
            case CreateCategoryCommand cmd:
                return serviceProvider.GetService<ICommandHandler<CreateCategoryCommand>>()!.Handle(cmd);
            case UpdateCategoryCommand cmd:
                return serviceProvider.GetService<ICommandHandler<UpdateCategoryCommand>>()!.Handle(cmd);
            case DeleteCategoryCommand cmd:
                return serviceProvider.GetService<ICommandHandler<DeleteCategoryCommand>>()!.Handle(cmd);
        }

        throw new CommandDispatcherException($"Found no match for {command.GetType()}");
    }


}