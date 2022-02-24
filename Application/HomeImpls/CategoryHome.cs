using Application.EntryContracts;
using Application.Profile.DTOs;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class CategoryHome : ICategoryHome
{
    private readonly ICategoryRepo categoryRepo;

    public CategoryHome(ICategoryRepo categoryRepo)
    {
        this.categoryRepo = categoryRepo;
    }

    public async Task<CategoryCardDTO> CreateCategoryAsync(CategoryCardDTO category)
    {
        Category newCat = new()
        {
            Id = Guid.NewGuid(),
            Title = category.Title,
            BackgroundColor = category.BackgroundColor,
            OwnerId = category.OwnerId
        };
        ValidateNewCategoryData(newCat);
        await ValitedateTitleIsFree(newCat);
        Category created = await categoryRepo.CreateAsync(newCat);
        category.Id = created.Id;
        return category;
    }

    public async Task<CategoryCardsContainerDTO> GetCategoryCardsDTOAsync(string teacherName)
    {
        ICollection<Category> categories = await categoryRepo.GetCategoriesByTeacherAsync(teacherName);

        List<CategoryCardDTO> categoryCards = new();

        // TODO get associated guide headers
        foreach (Category c in categories)
        {
            categoryCards.Add(
                new CategoryCardDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    BackgroundColor = c.BackgroundColor
                }
            );
        }

        CategoryCardsContainerDTO ccdto = new(categoryCards);
        return ccdto;
    }

    public Task UpdateCategoryAsync(CategoryCardDTO toUpdate)
    {
        Category categoryToUpdate = new()
        {
            Id = toUpdate.Id,
            Title = toUpdate.Title,
            BackgroundColor = toUpdate.BackgroundColor,
            OwnerId = toUpdate.OwnerId
        };
        ValidateNewCategoryData(categoryToUpdate);
        return categoryRepo.UpdateAsync(categoryToUpdate);
    }

    private void ValidateNewCategoryData(Category category)
    {
        if (string.IsNullOrEmpty(category.Title)) throw new ArgumentException("Title cannot be empty");
        if (category.Title.Length < 3) throw new ArgumentException("Title must be 3 or more characters");
        if (category.Title.Length > 25) throw new ArgumentException("Title must be 25 or fewer characters");
    }

    private async Task ValitedateTitleIsFree(Category category)
    {
        ICollection<Category> existing = await categoryRepo.GetCategoriesByTeacherAsync(category.OwnerId);
        Category? existingCategory = existing.FirstOrDefault(c => c.Title.Equals(category.Title, StringComparison.OrdinalIgnoreCase));
        if (existingCategory != null)
        {
            throw new ArgumentException("Category name already in use");
        }
    }
}