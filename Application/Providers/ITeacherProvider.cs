using Entities;

namespace Application.Providers;

public interface ITeacherProvider
{
    Task<Teacher> GetTeacherAsync(string userName);

}