using Application.RepositoryContracts;
using JsonData.Context;

namespace JsonData.Repositories;

public class JsonUnitOfWorkImpl : IUnitOfWork
{

    private readonly JsonDataContext context;


    public Task SaveChangesAsync()
    {
        context.SaveChanges();
        return Task.CompletedTask;
    }


    public JsonUnitOfWorkImpl(JsonDataContext context)
    {
        this.context = context;
    }
}