using Domain.Entities;
using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class GetTeacherForProfileView : IQueryHandler<TeacherQuery, TeacherDto>
{
    private readonly JsonDataContext context;

    public GetTeacherForProfileView(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<TeacherDto> Query(TeacherQuery query)
    {
        Teacher? teacher = context.Teachers
            .SingleOrDefault(teacher => teacher.Name.Equals(query.TeacherName));
        if (teacher == null)
        {
            throw new NotFoundException($"Teacher with name {query.TeacherName} was not found.");
        }

        TeacherDto resultDto = new(teacher.Name);
        return Task.FromResult(resultDto);
    }
}