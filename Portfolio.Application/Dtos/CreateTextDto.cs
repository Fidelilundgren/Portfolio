
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos;

public class CreateTextDto
{
    public int PageId { get; set; }
    public string TextContent { get; set; } = string.Empty;
    public string? CssClass { get; set; }
}
