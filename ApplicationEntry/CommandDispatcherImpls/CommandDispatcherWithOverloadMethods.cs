using Application.HandlerContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Domain.OperationResult;

namespace ApplicationEntry.CommandDispatcherImpls;

public class CommandDispatcherWithOverloadMethods
{
    private readonly IServiceProvider serviceProvider;

    public CommandDispatcherWithOverloadMethods(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<Result> Handle(CreateCategoryCommand command)
    {
        ICommandHandler<CreateCategoryCommand>? handler = serviceProvider.GetService(typeof(ICommandHandler<CreateCategoryCommand>)) as ICommandHandler<CreateCategoryCommand>;
        return handler.Handle(command);
    } 
    
    //... more methods with same signature, but different command type argument.
}