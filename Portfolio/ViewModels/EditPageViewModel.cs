using Portfolio.Application.Dtos;
using System.ComponentModel.DataAnnotations;
namespace Portfolio.ViewModels;

public class EditPageViewModel
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    public BlockDto? Heading { get; set; }
    public BlockDto? Text { get; set; }

    public HeadingFormViewModel HeadingStyling { get; set; } = new();
    public HeadingFormViewModel TextStyling { get; set; } = new();

    public PageDto ToPageDto(int pageId) => new()
    {
        Id = pageId,
        Title = Title
    };
}
