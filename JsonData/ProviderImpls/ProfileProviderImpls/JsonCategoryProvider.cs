﻿using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;
using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;
using Application.Features.ProfileDataLogic.ProviderContracts;
using JsonData.Context;

namespace JsonData.ProviderImpls.ProfileProviderImpls;

public class JsonCategoryProvider : ICategoryProvider
{
    private readonly JsonDataContext context;

    public JsonCategoryProvider(JsonDataContext context)
    {
        this.context = context;
    }

    // public Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    // {
    //     context.Teachers.First(t => t.Name.Equals(teacherName)).Categories.Select();
    //     ICollection<CategoryDto> categoryDtos = context.Categories.Where(c => c.OwnerId.Equals(teacherName))
    //         .Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).ToList();
    //     return Task.FromResult(categoryDtos);
    // }

    public Task<ICollection<CategoryWithGuidesAndResourcesDto>> GetCategoriesWithGuideHeadersByTeacherAsync(string teacher)
    {
        // get all categories for teacher
        ICollection<CategoryWithGuidesAndResourcesDto> categoriesWithGuidesAndExRes = context.Teachers
            .First(t => t.Name.Equals(teacher))
            .Categories
            .Select(c =>
                new CategoryWithGuidesAndResourcesDto(
                    new CategoryDto(c.Id, c.Title, c.BackgroundColor),
                    c.Guides.Select(g => new GuideHeaderDto(g.Id, g.Title)).ToList(),
                    c.ExternalResources.Select(er => new ExternalResourceDisplayDto(er.Id, er.Title, er.Url, er.Description)).ToList()
                )
            )
            .ToList();

        return Task.FromResult(categoriesWithGuidesAndExRes);
    }

    // private CategoryWithGuidesAndResourcesDto CreateUnCategorized(string teacher)
    // {
    //     CategoryWithGuidesAndResourcesDto unCatCwg = new();
    //     ICollection<GuideHeaderDto> guidesForUncategorized = context.Guides
    //         .Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher))
    //         .Select(g => new GuideHeaderDto(g.Id, g.Title)).ToList();
    //     ICollection<ExternalResourceDisplayDto> resourcesForUncategorized = context.ExternalResources
    //         .Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher))
    //         .Select(er => new ExternalResourceDisplayDto
    //         {
    //             Id = er.Id,
    //             Title = er.Title,
    //             Url = er.Url,
    //             Description = er.Description
    //         }).ToList();
    //     unCatCwg.Guides = guidesForUncategorized;
    //     unCatCwg.ExternalResources = resourcesForUncategorized;
    //     return unCatCwg;
    // }
}