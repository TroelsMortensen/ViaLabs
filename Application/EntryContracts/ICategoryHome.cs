using Application.DTOs;

namespace Application.EntryContracts;

public interface ICategoryHome
{
    public Task CreateCategory(CategoryDTO category);
}