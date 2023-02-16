namespace ViewData.ProfileInfo.Queries;

public record struct GetTeacher(string TeacherName);

public record struct GetProfileInfo(string TeacherName);

public record struct GetSingleCategoryInfo(Guid id);
