
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos;

public class CreateHeadingDto
{
    public int PageId { get; set; }
    public string TextContent { get; set; } = string.Empty;
    public int Order { get; set; }
    public string? CssClass { get; set; }
}
