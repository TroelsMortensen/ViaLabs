﻿namespace Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
}