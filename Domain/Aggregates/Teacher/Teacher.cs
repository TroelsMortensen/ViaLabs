using Domain.OperationResult;
using Domain.Values;

namespace Domain.Aggregates.Teacher;

public class Teacher
{
    
    public TeacherName Name { get; private set; }

    public static Result<Teacher> Create(TeacherName name)
    {
        Teacher teacher = new(name);
        return teacher;
    }

    private Teacher(TeacherName name)
    {
        Name = name;
    }

    private Teacher()
    {
    } // for JSON/EFC
}