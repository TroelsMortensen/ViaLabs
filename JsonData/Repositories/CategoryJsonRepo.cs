using Application.RepositoryContracts;
using Domain.Exceptions;
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

    public Task<Category> AddToTeacherAsync(Category category, string teacherName)
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
            throw new NotFoundException($"Could not update non-existing category with ID {categoryToUpdate.Id} and title {categoryToUpdate.Title}. Severe server problem");
        }

        _ = existing.Update(categoryToUpdate.Title, categoryToUpdate.BackgroundColor); // bit of a hack to do again here. May redo later.
        
        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid categoryId)
    {
        Teacher teacher = context.Teachers.First(teacher => teacher.Categories.FirstOrDefault(c => c.Id.Equals(categoryId)) != null);
        Category categoryToBeRemoved = teacher.Categories.First(c => c.Id.Equals(categoryId));
        bool categoryWasRemoved = teacher.Categories.Remove(categoryToBeRemoved);
        // Category toRemove = context.Categories.First(c => c.Id.Equals(categoryId));
         // = context.Categories.Remove(toRemove);
        
        if (!categoryWasRemoved)
        {
            throw new NotFoundException($"Could not find category with id {categoryId}");
        }

        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<Category> GetCategoryByIdAsync(Guid id)
    {
        Category? existingCategory = context.Categories.SingleOrDefault(category => category.Id.Equals(id));
        
        if (existingCategory is null)
        {
            throw new NotFoundException($"Category with ID {id} not found");
        }

        return Task.FromResult(existingCategory);
    }
}