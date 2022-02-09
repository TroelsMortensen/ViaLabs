using System.Collections.ObjectModel;

namespace Application.DTOs;

public class CategoryDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IList<GuideDTO> Guides { get; set; } = new List<GuideDTO>();

    public CategoryDTO(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
}