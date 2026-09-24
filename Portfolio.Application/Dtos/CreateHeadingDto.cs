
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos;

public class CreateHeadingDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Choose a page")]
    public int PageId { get; set; }

    [Required(ErrorMessage = "Heading is required")]
    public string TextContent { get; set; } = string.Empty;

    public int Order { get; set; }
    public string? CssClass { get; set; }
}
