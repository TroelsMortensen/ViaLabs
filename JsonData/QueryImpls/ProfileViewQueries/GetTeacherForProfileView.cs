using Domain.Entities;
using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class GetTeacherForProfileView : IQueryHandler<GetTeacher, TeacherHeaderDto>
{
    private readonly JsonDataContext context;

    public GetTeacherForProfileView(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<TeacherHeaderDto> Query(GetTeacher query)
    {
        Teacher? teacher = context.Teachers
            .SingleOrDefault(teacher => teacher.Name.Equals(query.TeacherName));
        if (teacher == null)
        {
            throw new NotFoundException($"Teacher with name {query.TeacherName} was not found.");
        }

        TeacherHeaderDto resultDto = new(teacher.Name);
        return Task.FromResult(resultDto);
    }
}