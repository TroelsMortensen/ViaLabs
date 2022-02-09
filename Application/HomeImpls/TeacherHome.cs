using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class TeacherHome : ITeacherHome
{
    private ITeacherRepo teacherRepo;

    public TeacherHome(ITeacherRepo teacherRepo)
    {
        this.teacherRepo = teacherRepo;
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
        return teacherRepo.GetApprovedTeacher(userName);
    }
}