using Domain.Aggregates;

namespace JsonData.Context;

public class ViaLabData
{
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<Teacher> UnApprovedTeachers { get; set; } = new List<Teacher>();

    public ICollection<Category> Categories { get; set; } = new List<Category>();

    public ICollection<Guide> Guides { get; set; } = new List<Guide>();
    public ICollection<ExternalResource> ExternalResources { get; set; } = new List<ExternalResource>();
    public ICollection<SlideContent> SlideContents { get; set; } = new List<SlideContent>();
}