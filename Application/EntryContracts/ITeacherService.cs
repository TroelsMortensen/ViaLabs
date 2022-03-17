using Entities;

namespace Application.EntryContracts;

public interface ITeacherService
{
    // public Task<User> GetUser(string userName);
    public bool IsViaTeacher(string userName);
    Task<Teacher?> GetTeacherAsync(string userName);
    
}