using Domain.Entities;

namespace ViewData.ProfileInfo.DTOs;

public class SlideVM
{
    public Guid Id { get; set; }
    public int Index { get; set; }
    public string Title { get; set; } = "";
    public Guid ContentId { get; set; }

    public SlideContent? SlideContent { get; set; } // this will be lazy loaded by the client

    public bool ShowTitleEditing { get; set; }
}