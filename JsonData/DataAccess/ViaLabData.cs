using Entities;

namespace JsonData.DataAccess;

public class ViaLabData
{
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<Teacher> UnApprovedTeachers { get; set; } = new List<Teacher>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();

    public ICollection<Guide> Guides { get; set; } = new List<Guide>();
}