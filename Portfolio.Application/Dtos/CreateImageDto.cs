namespace Portfolio.Application.Dtos;

public class CreateImageDto
{
    public int PageId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? CssClass { get; set; }
}
