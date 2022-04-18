using Application.RepositoryContracts;
using Entities;
using JsonData.DataAccess;

namespace JsonData.Repositories;

public class TeacherJsonRepo : ITeacherRepo
{
    private JsonDataContext context;

    public TeacherJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<Teacher?> GetApprovedTeacher(string name)
    {
        Teacher? firstOrDefault = context.ViaLabData.Teachers.FirstOrDefault(teacher => teacher.Name.Equals(name));
        return Task.FromResult(firstOrDefault);
    }
}