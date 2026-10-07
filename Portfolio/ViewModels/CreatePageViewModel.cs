using Portfolio.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels;

public class CreatePageViewModel
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heading is required")]
    public string HeadingText { get; set; } = string.Empty;

    public string? Text { get; set; }

    public HeadingFormViewModel HeadingStyling { get; set; } = new();
    public HeadingFormViewModel TextStyling { get; set; } = new();

    public PageDto ToPageDto() => new()
    {
        Title = Title
    };

    public CreateHeadingDto ToHeadingDto(int pageId) => new()
    {
        PageId = pageId,
        TextContent = HeadingText,
        CssClass = HeadingStyling.GetCss()
    };

    public CreateTextDto ToTextDto(int pageId) => new()
    {
        PageId = pageId,
        TextContent = Text,
        CssClass= TextStyling.GetCss()
    };
}
