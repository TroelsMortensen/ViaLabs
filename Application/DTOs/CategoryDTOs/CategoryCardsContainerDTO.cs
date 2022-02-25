using Entities;

namespace Application.Profile.DTOs;

public class CategoryCardsContainerDTO
{
    public List<Category> CategoryCards { get; set; }

    public CategoryCardsContainerDTO(List<Category> categoryCards)
    {
        CategoryCards = categoryCards;
    }
}