using Domain.OperationResult;

namespace Domain.Values;

public record TeacherName()
{
    private TeacherName(string name) : this()
    {
        Value = name;
    }

    public string Value { get; private set; }

    public static Result<TeacherName> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return new Result<TeacherName>("Teacher.Name", "Name cannot be empty");
        }

        return Result.Validation()
            .Require(() => name.Length >= 3,
                "Teacher.Name",
                "Name must be at least 3 characters")
            .Require(() => name.Length < 15,
                "Teacher.Name",
                "Name must be at most 15 characters")
            .IfSuccessElse(
                success: (r) => new Result<TeacherName>(new TeacherName(name)),
                failure: Result<TeacherName>.FromResult
            );
    }
}