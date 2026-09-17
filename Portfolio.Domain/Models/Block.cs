namespace Portfolio.Domain.Models;

public enum BlockType
{
    Heading,
    Text,
    Image,
    Link
}

public class Block
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
    public Page? Page { get; set; }
}
