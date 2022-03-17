using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class TeacherService : ITeacherService
{
    private readonly IRepoManager repoManager;

    public TeacherService(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
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
        return repoManager.TeacherRepo.GetApprovedTeacher(userName);
    }
}