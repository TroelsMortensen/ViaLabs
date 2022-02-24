namespace Application.Profile.DTOs;

public class CategoryCardsContainerDTO
{
    public List<CategoryCardDTO> CategoryCards { get; set; }

    public CategoryCardsContainerDTO(List<CategoryCardDTO> categoryCards)
    {
        CategoryCards = categoryCards;
    }
}