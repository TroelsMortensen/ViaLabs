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


    public static void ShowSnackMessage(string msg, SnackType snackType = SnackType.Positive)
    {
        OnSnackMsg.Invoke(msg, snackType);
    }
}