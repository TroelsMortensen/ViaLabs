namespace BlazorServerUI.Handlers;

public class SnackBarHandler
{


    public static event Action<string> OnSnackMsg = null!;

    
    public static void ShowSnackMessage(string msg)
    {
        OnSnackMsg.Invoke(msg);
    }
}