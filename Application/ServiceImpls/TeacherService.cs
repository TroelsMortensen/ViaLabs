using Application.RepositoryContracts;
using Application.ServiceContracts;
using Entities;

namespace Application.ServiceImpls;

public class TeacherService : ITeacherService
{
    private readonly IRepoUOW repoUow;

    public TeacherService(IRepoUOW repoUow)
    {
        this.repoUow = repoUow;
    }

    public bool IsViaTeacher(string userName)
    {
        if (string.IsNullOrEmpty(userName)) return false;
        if (!userName.StartsWith("VIA\\")) return false;
        string cleanedUserName = userName.Replace("VIA\\", "");
        if (cleanedUserName.Any(char.IsDigit)) return false;
        return true;
    }

    public Task<Teacher?> GetTeacherAsync(string userName)
    {
        return repoUow.TeacherRepo.GetApprovedTeacher(userName);
    }
}