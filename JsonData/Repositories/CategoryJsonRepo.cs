using Application.RepositoryContracts;
using Domain.Models;
using JsonData.Context;

namespace JsonData.Repositories;

public class CategoryJsonRepo : ICategoryRepo
{
    private readonly JsonDataContext context;

    public CategoryJsonRepo(JsonDataContext context)
    {
        this.context =  context;
    }

    public Task<Category> CreateAsync(Category category)
    {
        category.AssignId( Guid.NewGuid());
        context.Categories.Add(category);
        Category toReturn = context.Categories.First(c => c.Id.Equals(category.Id));
        return Task.FromResult(toReturn);
    }

    public Task<ICollection<Category>> GetCategoriesByTeacherAsync(string teacherId)
    {
        ICollection<Category> categories = context.Categories.Where(c => c.OwnerId.Equals(teacherId)).ToList();
        return Task.FromResult(categories);
    }

    public Task UpdateAsync(Category categoryToUpdate)
    {
        Category? existing = context.Categories.FirstOrDefault(c => c.Id.Equals(categoryToUpdate.Id));
        if (existing == null)
        {
            throw new Exception("Could not update non-existing category. Serious problem");
        }

        context.Categories.Remove(existing);
        context.Categories.Add(categoryToUpdate);
        
        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid categoryId)
    {
        Category toRemove = context.Categories.First(c => c.Id.Equals(categoryId));
        if (!context.Categories.Remove(toRemove))
        {
            throw new Exception("Removed nothing, something went wrong");
        }

        return Task.CompletedTask;
    }
}