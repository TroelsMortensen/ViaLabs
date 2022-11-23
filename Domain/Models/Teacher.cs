using System.Text.Json.Serialization;
using SharedKernel.Results;

namespace Domain.Models;

public class Teacher
{
    public string Name { get; init; }

    
    public ICollection<Category> Categories { get; init; } 

    public static Result<Teacher> Create(string name)
    {
        Teacher teacher = new(name, new List<Category>());
        return new(teacher);
    }

    private Teacher(string name, ICollection<Category> categories)
    {
        Name = name;
        Categories = categories;
    }
    
    private Teacher(){} // for JSON/EFC

}