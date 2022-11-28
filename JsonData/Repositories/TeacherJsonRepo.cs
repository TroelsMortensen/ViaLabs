using Application.RepositoryContracts;
using Domain.Exceptions;
using Domain.Models;
using JsonData.Context;

namespace JsonData.Repositories;

public class TeacherJsonRepo : ITeacherRepo
{
    private CollectionsDataContext context;

    public TeacherJsonRepo(CollectionsDataContext context)
    {
        this.context = context;
    }

    public Task<Teacher> GetApprovedTeacher(string name)
    {
        Teacher? firstOrDefault = context.Teachers.FirstOrDefault(teacher => teacher.Name.Equals(name));
        if (firstOrDefault is null)
            throw new NotFoundException($"Teacher with name {name} was not found. Severe server error.");
        return Task.FromResult(firstOrDefault);
    }
}