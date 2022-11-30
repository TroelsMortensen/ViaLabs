﻿using SharedKernel.OperationResult;

namespace Domain.Entities;

public class Teacher
{
    public string Name { get; init; }

    public ICollection<Category> Categories { get; init; } // make private? :/ some day

    public static Result<Teacher> Create(string name)
    {
        name = name?.Trim(' ');
        Teacher teacher = new(name, new List<Category>());
        Result validationResult = Validate(name);

        return validationResult.HasErrors ? new(validationResult.Errors) : new(teacher);
    }
    
    private static Result Validate(string name)
    {
        Result result = new();

        if (string.IsNullOrEmpty(name))
        {
            result.AddError("Teacher.Name", "Name cannot be empty");
            return result;
        }

        if (name.Length < 3)
        {
            result.AddError("Teacher.Name", "Name must be at least 3 characters");
        }

        if (name.Length > 15)
        {
            result.AddError("Teacher.Name", "Name must be at most 15 characters");
        }

        return result;
    }

    private Teacher(string name, ICollection<Category> categories)
    {
        Name = name;
        Categories = categories;
    }

    private Teacher()
    {
    } // for JSON/EFC
}