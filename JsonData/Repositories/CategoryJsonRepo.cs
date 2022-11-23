using Application.RepositoryContracts;
using Domain.Models;
using JsonData.Context;

namespace JsonData.Repositories;

public class CategoryJsonRepo : ICategoryRepo
{
    private readonly JsonDataContext context;

    public CategoryJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<Category> AddToTeacher(Category category, string teacherName)
    {
        Teacher teacher = context.Teachers.Single(t => t.Name.Equals(teacherName));
        teacher.Categories.Add(category);
        Guid id = category.Id;
        context.SaveChanges();
        Category toReturn = context.Categories.Single(cat => cat.Id.Equals(id));
        return Task.FromResult(toReturn);
    }

    public Task<IEnumerable<Category>> GetCategoriesByTeacherAsync(string teacherName)
    {
        IEnumerable<Category> categories = context.Teachers.Single(t => t.Name.Equals(teacherName)).Categories;
        return Task.FromResult(categories);
    }

    public Task UpdateAsync(Category categoryToUpdate)
    {
        Category? existing = context.Categories.SingleOrDefault(c => c.Id.Equals(categoryToUpdate.Id));
        if (existing is null)
        {
            throw new Exception($"Could not update non-existing category with ID {categoryToUpdate.Id}. Serious problem");
        }

        throw new Exception("The below out-commented code would not work. The category would loose the connection to teacher");
        // context.Categories.Remove(existing);
        // context.Categories.Add(categoryToUpdate);

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

        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<Category> GetCategoryById(Guid id)
    {
        Category? existingCategory = context.Categories.SingleOrDefault(category => category.Id.Equals(id));
        
        if (existingCategory is null)
        {
            throw new Exception($"Category with ID {id} not found");
        }

        return Task.FromResult(existingCategory);
    }
}