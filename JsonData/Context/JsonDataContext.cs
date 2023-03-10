﻿using Domain.Entities;
using JsonData.JsonSerializationUtils;

namespace JsonData.Context;

public class JsonDataContext : IDisposable
{
    private readonly IJsonHelper jsonHelper;
    private readonly string path = "vialabs.json";

    private ViaLabData? data;
    private ViaLabData Data
    {
        get => data ??= LoadData(); // auto-completed into this from larger get body.
        set => data = value;
    }

    internal ICollection<Teacher> Teachers => Data.Teachers;
    internal ICollection<Category> Categories => Data.Categories;
    internal ICollection<Guide> Guides => Data.Guides;

    internal ICollection<ExternalResource> ExternalResources => Data.ExternalResources;

    internal ICollection<SlideContent> SlideContents => Data.SlideContents;

    public JsonDataContext(IJsonHelper jsonHelper)
    {
        this.jsonHelper = jsonHelper;
        
        if (!File.Exists(path))
        {
            ViaLabData vld = new()
            {
                Teachers = new List<Teacher>()
                {
                    Teacher.Create("VIA\\TRMO").Value
                },
                UnApprovedTeachers = new List<Teacher>(),
            };
            string vldAsJson = jsonHelper.Serialize(vld);
            File.WriteAllText(path, vldAsJson);
        } else
        {
            Data = LoadData();
        }
    }

    internal async Task SaveChangesAsync()
    {
        await SaveData();
        Data = null;
    }  
    
    private ViaLabData LoadData()
    {
        string vldAsJson = File.ReadAllText(path);
        ViaLabData resultData = jsonHelper.Deserialize<ViaLabData>(vldAsJson);
        return resultData;
    }

    private async Task SaveData()
    {
        if (Data is null) 
            throw new NullReferenceException("You are trying to save non-existing data. Severe server error");
        
        string vldAsJson = jsonHelper.Serialize(Data);
        await File.WriteAllTextAsync(path, vldAsJson);
    }

    public void Dispose()
    {
        Data = null;
    }
}