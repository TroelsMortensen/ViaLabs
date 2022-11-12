using System.Text;

namespace Domain.Exceptions;

public class DataValidationException : Exception
{
    public IEnumerable<string> Errors => errors;

    private readonly ICollection<string> errors;
    private readonly string msg;


    public DataValidationException() : this("Invalid data.")
    {
    }

    public DataValidationException(string message) 
    {
        msg = message;
        errors = new List<string>();
    }


    public void AddError(string error)
    {
        errors.Add(error);
    }

    public override string Message
    {
        get
        {
            StringBuilder sb = new();
            
            foreach (string error in errors)
            {
                sb.AppendLine(error);
            }

            return msg + "\n" + sb.ToString();
        }
    }

    public void ThrowIfErrors()
    {
        if (errors.Any())
        {
            throw this;
        }
    }
}