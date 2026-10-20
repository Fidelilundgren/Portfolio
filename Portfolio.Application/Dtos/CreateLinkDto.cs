namespace Portfolio.Application.Dtos;

public class CreateLinkDto
{
    public int PageId { get; set; }
    public string LinkUrl { get; set; } = string.Empty;
    public string LinkText { get; set; } = string.Empty;
    public string? CssClass { get; set; }

}
