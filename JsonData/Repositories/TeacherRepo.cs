using Application.Repositories;
using Entities;

namespace JsonData.Repositories;

public class TeacherRepo : ITeacherRepo
{
    private JsonDataContext context;

    public TeacherRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<Teacher> GetApprovedTeacher(string userName)
    {
        throw new NotImplementedException();
    }
}