namespace Application.DTOs.CategoryDTOs;

public class CategoryCardsContainerDto
{
    public IEnumerable<CategoryDto> CategoryCards { get; set; }

    public CategoryCardsContainerDto(List<CategoryDto> categoryCards)
    {
        CategoryCards = categoryCards;
    }
}