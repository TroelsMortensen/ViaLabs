using Domain.Aggregates;
using Domain.Aggregates.Teacher;

namespace Application.RepositoryContracts;

public interface ITeacherRepo
{
    public Task<Teacher> GetApprovedTeacher(string name);
}