using Application.Profile.DTOs;
using Entities;

namespace Application.EntryContracts;

public interface ICategoryHome
{
    public Task<CategoryCardDTO> CreateCategoryAsync(CategoryCardDTO category);
    Task<CategoryCardsContainerDTO> GetCategoryCardsDTOAsync(string teacherName);
    Task UpdateCategoryAsync(CategoryCardDTO toUpdate);
}