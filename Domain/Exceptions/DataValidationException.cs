using System.Text;

namespace Domain.Exceptions;

public class DataValidationException : Exception
{
    private IEnumerable<string> Errors;
    private string msg;
    public DataValidationException(string msg, ICollection<string> errors)
    {
        Errors = errors;
        this.msg = msg;
    }

    public override string Message
    {
        get
        {
            StringBuilder sb = new();
            foreach (string error in Errors)
            {
                sb.AppendLine(error);
            }

            return msg + "\n" + sb.ToString();
        }
    }
}