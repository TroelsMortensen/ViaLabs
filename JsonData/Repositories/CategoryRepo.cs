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

    public Task<Category> CreateAsync(Category category)
    {
        category.Id = Guid.NewGuid();
        context.ViaLabData.Categories.Add(category);
        context.SaveChanges();
        Category toReturn = context.ViaLabData.Categories.First(c => c.Id.Equals(category.Id));
        return Task.FromResult(toReturn);
    }

    public Task<Category?> GetCategoryByTitleAndTeacherAsync(string categoryTitle, string ownerName)
    {
        Category? existing = context.ViaLabData.Categories.FirstOrDefault(c => c.Title.Equals(categoryTitle) && c.Owner.Name.Equals(ownerName));
        return Task.FromResult(existing);
    }
}