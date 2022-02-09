using Entities;

namespace Application.Repositories;

public interface ITeacherRepo
{
    public Task<Teacher?> GetApprovedTeacher(string name);
}