using Application.Repositories;
using Entities;

namespace JsonData.Repositories;

public class CategoryRepo : ICategoryRepo
{
    private JsonDataContext context;

    public CategoryRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(Category category)
    {
        category.Id = Guid.NewGuid();
        
        return Task.CompletedTask;
    }
}