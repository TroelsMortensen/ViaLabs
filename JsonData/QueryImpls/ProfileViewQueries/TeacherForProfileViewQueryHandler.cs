using Domain.Aggregates;
using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class TeacherForProfileViewQueryHandler : IQueryHandler<TeacherQuery, TeacherVM>
{
    private readonly JsonDataContext context;

    public TeacherForProfileViewQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<TeacherVM> Query(TeacherQuery query)
    {
        Teacher? teacher = context.Teachers
            .SingleOrDefault(teacher => teacher.Name.Equals(query.TeacherName));
        if (teacher == null)
        {
            throw new NotFoundException($"Teacher with name {query.TeacherName} was not found.");
        }

        TeacherVM resultVm = new(teacher.Name);
        return Task.FromResult(resultVm);
    }
}