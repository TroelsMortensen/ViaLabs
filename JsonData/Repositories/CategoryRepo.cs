﻿using Application.Profile.DTOs;
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

    public Task<ICollection<Category>> GetCategoriesByTeacherAsync(string teacherId)
    {
        ICollection<Category> categories = context.ViaLabData.Categories.
            Where(c => c.OwnerId.Equals(teacherId)).
            ToList();
        return Task.FromResult(categories);
    }

    public Task UpdateAsync(Category categoryToUpdate)
    {
        Category? existing = context.ViaLabData.Categories.FirstOrDefault(c => c.Id.Equals(categoryToUpdate.Id));
        if (existing == null)
        {
            throw new Exception("Could not update non-existing category. Serious problem");
        }

        existing.Title = categoryToUpdate.Title;
        existing.BackgroundColor = categoryToUpdate.BackgroundColor;
        context.SaveChanges();
        return Task.CompletedTask;
    }
}