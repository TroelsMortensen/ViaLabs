namespace Domain.NotificationPattern;

public class Result<T>
{
    /**
     * This was an attempt at the Notification pattern. Similar to NuGet package ErrorOr.
     * I was not convinced I liked the approach, and stuck with thrown a custom exception instead.
     * I feel that reduced result.HasErrors checks.
     * The code may be less clear because of these glorified GO-TO statements. So I leave this class here, in case I change my names later.
     */
    
    // public IEnumerable<string> Errors => errors.AsReadOnly();
    // public bool HasErrors => Errors.Any();
    // public T Value { get; set; } = default!;
    //
    // private readonly List<string> errors = new List<string>();
    //
    // public void AddError(string msg)
    // {
    //     errors.Add(msg);
    // }
}