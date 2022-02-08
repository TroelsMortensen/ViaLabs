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
        if (!userName.StartsWith("VIA\\")) return false;
        string cleanedUserName = userName.Replace("VIA\\", "");
        if (cleanedUserName.Any(char.IsDigit)) return false;
        return true;
    }

    public Teacher GetTeacher(string userName)
    {
        throw new NotImplementedException();
    }
}