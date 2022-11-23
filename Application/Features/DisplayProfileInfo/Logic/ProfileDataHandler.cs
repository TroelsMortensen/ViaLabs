namespace Application.Features.DisplayProfileInfo.Logic;

public class ProfileDataHandler : IProfileDataHandler
{

    public bool IsViaTeacher(string userName)
    {
        if (string.IsNullOrEmpty(userName)) return false;
        if (!IsViaAccount(userName)) return false;
        
        return true;
    }

    private static bool IsViaAccount(string userName)
    {
        return userName.StartsWith("VIA\\");
    }
}