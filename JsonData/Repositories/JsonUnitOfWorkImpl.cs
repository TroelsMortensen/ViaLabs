using Application.RepositoryContracts;
using JsonData.Context;

namespace JsonData.Repositories;

internal class JsonUnitOfWorkImpl : IUnitOfWork
{

    private readonly JsonDataContext context;


    public Task SaveChanges()
    {
        context.SaveChanges();
        return Task.CompletedTask;
    }


    internal JsonUnitOfWorkImpl(JsonDataContext context)
    {
        this.context = context;
    }
}