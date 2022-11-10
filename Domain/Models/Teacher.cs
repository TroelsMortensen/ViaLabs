namespace Domain.Models;

public class Teacher
{
    public string Name { get; private set; }

    public ICollection<Category> Categories { get; private set; } = new List<Category>();

    public Teacher(string name)
    {
        Name = name;
        throw new Exception("Missing domain validation here");
    }

    public void AddCategory(Category cat)
    {
        Categories.Add(cat);
    }
}