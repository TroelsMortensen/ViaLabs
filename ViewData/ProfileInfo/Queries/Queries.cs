namespace ViewData.ProfileInfo.Queries;

public record struct TeacherQuery(string TeacherName);

public record struct GetProfileInfo(string TeacherName);

public record struct SingleCategoryInfoQuery(Guid id);
