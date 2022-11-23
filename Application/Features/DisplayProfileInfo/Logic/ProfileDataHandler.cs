namespace Application.Features.DisplayProfileInfo.Logic;

public class ProfileDataHandler : IProfileDataHandler
{

    public bool IsViaTeacher(string userName)
    {
        if (string.IsNullOrEmpty(userName)) return false;
        if (IsNotVia(userName)) return false;
        
        return true;
    }

    private static bool IsNotVia(string userName)
    {
        return userName.StartsWith("VIA\\");
    }
}