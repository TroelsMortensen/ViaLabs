using ViewData.ProfileInfo.DTOs;

namespace ViewData.ProfileInfo.Queries;

public record TeacherQuery(string TeacherName) : IQuery<TeacherVM>;

public record ProfileInfoOverviewQuery(string TeacherName) : IQuery<ICollection<CategoryWithGuidesAndResourcesVM>>;

public record CategoryInfoByIdQuery(Guid Id) : IQuery<CategoryVM>;

public record GuideHeaderQuery(Guid Id) : IQuery<GuideHeaderVM>;

public record GuideDataForEditQuery(Guid Id) : IQuery<GuideDataVM>;

public record SingleSlideStepQuery(Guid SlideStepId) : IQuery<SlideStepVM>;
