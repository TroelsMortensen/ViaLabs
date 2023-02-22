using Application.RepositoryContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Application.UseCases.CategoryUseCases.CategoryDelete;
using Application.UseCases.CategoryUseCases.CategoryUpdate;
using Dispatcher.Exceptions;
using Domain.OperationResult;
using JsonData.Context;
using JsonData.JsonSerializationUtils;
using JsonData.Repositories;

namespace Dispatcher.DispatcherImplementations;

public class CommandDispatcherWithOverloadMethods : ICommandDispatcher
{
    public Task<Result> Dispatch<TCommand>(TCommand command) where TCommand : class
    {
        switch (command)
        {
            case CreateCategoryCommand cmd:
                return new CategoryCreateHandler(
                    CreateUnitOfWork(),
                    CreateCategoryRepository()
                ).Handle(cmd);
            case UpdateCategoryCommand cmd:
                return new CategoryUpdateHandler(
                    CreateUnitOfWork(),
                    CreateCategoryRepository()
                ).Handle(cmd);
            case DeleteCategoryCommand: break;
        }

        throw new CommandDispatcherException($"Found no match for {command.GetType()}");
    }

    private static ICategoryRepo CreateCategoryRepository()
    {
        return new CategoryJsonRepo(CreateJsonDataContext());
    }

    private static JsonDataContext CreateJsonDataContext()
    {
        return new JsonDataContext(new SystemNetJsonSerializerHelper());
    }

    private static JsonUnitOfWorkImpl CreateUnitOfWork()
    {
        return new JsonUnitOfWorkImpl(
            CreateJsonDataContext()
        );
    }
}