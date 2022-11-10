﻿namespace Domain.Models;

public class Guide
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public bool IsPublished { get; private set; }
    public bool IsDisplayingStepNums { get; private set; }

    public ICollection<Slide> Slides { get; private set; } = new List<Slide>();

    public Guide(string title, bool isPublished, bool displayStepNums)
    {
        Title = title;
        IsPublished = isPublished;
        IsDisplayingStepNums = displayStepNums;
    }

    public void Update(Guide guide)
    {
        Title = guide.Title;
        IsPublished = guide.IsPublished;
        IsDisplayingStepNums = guide.IsDisplayingStepNums;
        throw new Exception("Missing domain validation here");
    }

    public void Publish()
    {
        IsPublished = true;
    }

    public void UnPublish()
    {
        IsPublished = false;
    }

    public void DisplayStepNums(bool shouldDisplay)
    {
        IsDisplayingStepNums = shouldDisplay;
    }

    public void AddSlide(Slide s)
    {
        Slides.Add(s);
    }
    
}