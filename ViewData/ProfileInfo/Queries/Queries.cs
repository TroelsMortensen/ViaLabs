using ViewData.ProfileInfo.DTOs;

namespace ViewData.ProfileInfo.Queries;

public record TeacherQuery(string TeacherName) : IQuery<TeacherDto>;

public record ProfileInfoOverviewQuery(string TeacherName) : IQuery<ICollection<CategoryWithGuidesAndResourcesDto>>;

public record SingleCategoryInfoQuery(Guid Id) : IQuery<CategoryDto>;
