using Application.Profile.DTOs;
using Entities;

namespace Application.EntryContracts;

public interface ICategoryHome
{
    public Task<Category> CreateCategoryAsync(Category category);
    Task<CategoryCardsContainerDTO> GetCategoryCardsDTOAsync(string teacherName);
    Task UpdateCategoryAsync(Category toUpdate);
}