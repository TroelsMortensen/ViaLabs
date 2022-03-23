using Entities;

namespace Application.RepositoryContracts;

public interface ITeacherRepo
{
    public Task<Teacher?> GetApprovedTeacher(string name);
}