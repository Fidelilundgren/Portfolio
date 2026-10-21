namespace Portfolio.Application.Dtos;

public class PageContentDto
{
    public int PageId { get; set; }
    public string Title { get; set; } = string.Empty;

    public string HeadingText { get; set; } = string.Empty;
    public string? HeadingCss { get; set; }

    public string? Text { get; set; }
    public string? TextCss { get; set; }

    public string? ImageUrl { get; set; }
    public string? ImageCss { get; set; }

    public string? LinkUrl { get; set; }
    public string? LinkText { get; set; }
    public string? LinkCss { get; set; }
}