using Application.Features.ProfileDataLogic.LogicContracts;

namespace Application.Features.ProfileDataLogic.LogicImpls;

public class TeacherLogic : ITeacherLogic
{

    public bool IsViaTeacher(string userName)
    {
        if (string.IsNullOrEmpty(userName)) return false;
        if (!userName.StartsWith("VIA\\")) return false;
        string cleanedUserName = userName.Replace("VIA\\", "");
        if (cleanedUserName.Any(char.IsDigit)) return false;
        return true;
    }

}