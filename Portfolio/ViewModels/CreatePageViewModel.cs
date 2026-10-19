using Portfolio.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels;

public class CreatePageViewModel
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(10, ErrorMessage = "Title can contain maximum 10 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heading is required")]
    [StringLength(20, ErrorMessage = "Heading can contain maximum 20 characters")]
    public string HeadingText { get; set; } = string.Empty;

    [StringLength(5000, ErrorMessage = "Text can contain maximum 5000 character")]
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
