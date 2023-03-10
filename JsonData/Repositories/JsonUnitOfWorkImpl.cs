using Application.RepositoryContracts;
using JsonData.Context;

namespace JsonData.Repositories;

public class JsonUnitOfWorkImpl : IUnitOfWork
{

    private readonly JsonDataContext context;

    public Task SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }

    public JsonUnitOfWorkImpl(JsonDataContext context)
    {
        this.context = context;
    }
}