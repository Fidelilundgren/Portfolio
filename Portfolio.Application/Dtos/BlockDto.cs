using Portfolio.Domain.Models;

namespace Portfolio.Application.Dtos;

public class BlockDto
{
    public int Id { get; set; }
    public BlockType Type { get; set; }
    public int Order { get; set; }

    public string? TextContent { get; set; }
    public string? ImageUrl { get; set; }
    public string? LinkUrl { get; set; }
    public string? LinkText { get; set; }
    public string? CssClass { get; set; }

    public int PageId { get; set; }
}
