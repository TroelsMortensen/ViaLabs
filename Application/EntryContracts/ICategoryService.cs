﻿using Application.Profile.DTOs;
using Entities;

namespace Application.EntryContracts;

public interface ICategoryService
{
    public Task<Category> CreateAsync(Category category);
    Task<CategoryCardsContainerDTO> GetCategoryCardsDTOAsync(string teacherName);
    Task UpdateAsync(Category toUpdate);
    Task DeleteAsync(Guid categoryId);
}