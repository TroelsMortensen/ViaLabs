namespace Domain.Models;

public class Teacher
{
    public string Name { get; private set; }

    public Teacher(string name)
    {
        Name = name;
        throw new Exception("Missing domain validation here");
    }
}