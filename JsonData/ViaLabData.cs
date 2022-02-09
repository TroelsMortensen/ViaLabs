using Entities;

namespace JsonData;

public class ViaLabData
{
    public ICollection<Teacher> Teachers { get; set; } = null!;
    public ICollection<Teacher> UnApprovedTeachers { get; set; } = null!;
}