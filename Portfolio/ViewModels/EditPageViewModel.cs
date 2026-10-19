using Portfolio.Application.Dtos;
using System.ComponentModel.DataAnnotations;
namespace Portfolio.ViewModels;

public class EditPageViewModel
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(10, ErrorMessage = "Title can contain maximum 10 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heading is required")]
    [StringLength(20, ErrorMessage = "Heading can contain maximum 20 characters")]
    public string HeadingText { get; set; } = string.Empty;

    [StringLength(5000, ErrorMessage = "Text can contain maximum 5000 character")]
    public string? TextContent { get; set; }

    public BlockDto? Heading { get; set; }
    public BlockDto? Text { get; set; }

    public HeadingFormViewModel HeadingStyling { get; set; } = new();
    public HeadingFormViewModel TextStyling { get; set; } = new();

    public PageDto ToPageDto(int pageId) => new()
    {
        Id = pageId,
        Title = Title
    };

    public CreateTextDto ToTextDto(int pageId) => new()
    {
        PageId = pageId,
        TextContent = TextContent,
        CssClass = TextStyling.GetCss()
    };
}
