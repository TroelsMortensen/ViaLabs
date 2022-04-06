using Application.RepositoryContracts;
using Entities;
using JsonData.DataAccess;

namespace JsonData.Repositories;

public class TeacherRepo : ITeacherRepo
{
    private JsonDataContext context;

    public TeacherRepo(IDbContext context)
    {
        this.context = (JsonDataContext)context;
    }

    public Task<Teacher?> GetApprovedTeacher(string name)
    {
        Teacher? firstOrDefault = context.ViaLabData.Teachers.FirstOrDefault(teacher => teacher.Name.Equals(name));
        return Task.FromResult(firstOrDefault);
    }
}