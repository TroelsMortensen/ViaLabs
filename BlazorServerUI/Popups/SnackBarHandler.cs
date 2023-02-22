namespace BlazorServerUI.Popups;

public class SnackBarHandler
{

    public enum SnackType
    {
        Positive,
        Neutral,
        Negative
    }

    public static event Action<string, SnackType> OnSnackMsg = null!;


    public static void ShowSuccess(string msg)
    {
        OnSnackMsg.Invoke(msg, SnackType.Positive);
    }

    public static void ShowInfo(string msg)
    {
        OnSnackMsg.Invoke(msg, SnackType.Neutral);
    }

    public static void ShowError(string msg)
    {
        OnSnackMsg.Invoke(msg, SnackType.Negative);
    }
}