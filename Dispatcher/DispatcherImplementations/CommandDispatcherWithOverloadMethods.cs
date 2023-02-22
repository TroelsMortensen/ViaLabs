using Application.RepositoryContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Application.UseCases.CategoryUseCases.CategoryDelete;
using Application.UseCases.CategoryUseCases.CategoryUpdate;
using Dispatcher.Exceptions;
using Domain.OperationResult;
using Microsoft.Extensions.DependencyInjection;

namespace Dispatcher.DispatcherImplementations;

public class CommandDispatcherWithOverloadMethods : ICommandDispatcher
{

    private readonly IServiceProvider serviceProvider;

    public CommandDispatcherWithOverloadMethods(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<Result> Dispatch<TCommand>(TCommand command) where TCommand : class
    {
        
        switch (command)
        {
            case CreateCategoryCommand cmd:
                return new CategoryCreateHandler(
                    serviceProvider.GetService<IUnitOfWork>()!,
                    serviceProvider.GetService<ICategoryRepo>()!
                ).Handle(cmd);
            case UpdateCategoryCommand cmd:
                return new CategoryUpdateHandler(
                    serviceProvider.GetService<IUnitOfWork>()!,
                    serviceProvider.GetService<ICategoryRepo>()!
                ).Handle(cmd);
            case DeleteCategoryCommand cmd:
                return new CategoryDeleteHandler(
                    serviceProvider.GetService<IUnitOfWork>()!,
                    serviceProvider.GetService<ICategoryRepo>()!,
                    serviceProvider.GetService<IGuideRepo>()!,
                    serviceProvider.GetService<IExternalResourceRepo>()!
                ).Handle(cmd);
        }

        throw new CommandDispatcherException($"Found no match for {command.GetType()}");
    }


}