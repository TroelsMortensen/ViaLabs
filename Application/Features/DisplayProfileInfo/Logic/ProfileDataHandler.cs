namespace Application.Features.DisplayProfileInfo.Logic;

public class ProfileDataHandler : IProfileDataHandler
{

    public bool IsViaTeacher(string userName)
    {
        if (string.IsNullOrEmpty(userName)) return false;
        if (!userName.StartsWith("VIA\\")) return false;
        string cleanedUserName = userName.Replace("VIA\\", "");
        if (cleanedUserName.Any(char.IsDigit)) return false; // but why this?
        return true;
    }

}