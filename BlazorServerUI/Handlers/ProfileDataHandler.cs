﻿using Application.DTOs.CategoryDTOs;
using Application.DTOs.GuideDTOs;
using Application.ProviderContracts;

namespace BlazorServerUI.Handlers;

public class ProfileDataHandler
{
    public CategoriesWithGuideHeadersDto Categories { get; set; } = null!;

    public Action OnCategoryAdded { get; set; } = null!;
    public Action<Guid> OnCategoryDeleted { get; set; } = null!;
    public Action OnGuideAdded { get; set; } = null!;
    public Action OnCategoryUpdated { get; set; } = null!;

    // TODO public Action< Type { get; set; }  external resource added

    private readonly ICategoryProvider categoryProvider;

    public ProfileDataHandler(ICategoryProvider categoryProvider)
    {
        this.categoryProvider = categoryProvider;
    }

    public async Task PopulateAsync(string teacher)
    {
        Categories = await categoryProvider.GetCategoriesWithGuideHeadersAsync(teacher);
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        CategoryWithGuidesDto c = new()
        {
            Category = categoryDto
        };
        Categories.CategoriesWithGuides.Add(c);
        OnCategoryAdded?.Invoke();
    }

    public void AddGuideToCategory(GuideHeaderDto created, CategoryDto? category)
    {
        CategoryWithGuidesDto? cwgw;
        if (category != null)
        {
            cwgw = Categories!.CategoriesWithGuides.First(c => c.Category != null && c.Category!.Id.Equals(category.Id));
        }
        else
        {
            cwgw = Categories!.CategoriesWithGuides.First(c => c.Category == null);
        }

        cwgw.Guides.Add(created);
        Console.WriteLine("Added, now invoking");
        OnGuideAdded?.Invoke();
    }
}