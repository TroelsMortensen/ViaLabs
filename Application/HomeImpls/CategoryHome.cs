using Application.DTOs;
using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class CategoryHome : ICategoryHome
{
    private ICategoryRepo categoryRepo;

    public CategoryHome(ICategoryRepo categoryRepo)
    {
        this.categoryRepo = categoryRepo;
    }

    public Task CreateCategory(CategoryDTO category)
    {
        ValidateCategory(category);
        Task task = categoryRepo.CreateAsync(new Category
        {
            Title = category.Title
        });
        return task;
    }

    private void ValidateCategory(CategoryDTO category)
    {
        
    }
}