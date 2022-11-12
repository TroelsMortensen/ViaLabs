namespace Domain.Models;

public class Teacher
{
    public string Name { get; private set; }

    public ICollection<Category> Categories { get; private set; } = new List<Category>();

    public Teacher(string name)
    {
        Name = name;
        ValidateData();
    }

    private void ValidateData()
    {
        // anything? I get this from the log in framework. But I shouldn't depend on that, though. So I'll make up some rules at some point.
    }

    public void AddCategory(Category cat)
    {
        Categories.Add(cat);
    }
}