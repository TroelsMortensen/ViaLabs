using Domain.Aggregates;

namespace Application.RepositoryContracts;

public interface ITeacherRepo
{
    public Task<Teacher> GetApprovedTeacher(string name);
}