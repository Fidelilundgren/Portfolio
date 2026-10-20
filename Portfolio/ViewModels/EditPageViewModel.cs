using Microsoft.AspNetCore.Components.Forms;
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

    [Url(ErrorMessage = "Must be a valid URL")]
    public string? LinkUrl { get; set; }

    [StringLength(50, ErrorMessage = "Link text can contain maximum 50 characters")]
    public string? LinkText { get; set; }

    public BlockDto? Heading { get; set; }
    public BlockDto? Text { get; set; }
    public BlockDto? Link { get; set; }

    public string? ImageUrl { get; set; }
    public BlockDto? Image { get; set; }
    public IBrowserFile? UploadedImage { get; set; }
    public string? ImageError { get; set; }

    public HeadingFormViewModel HeadingStyling { get; set; } = new();
    public HeadingFormViewModel TextStyling { get; set; } = new();
    public HeadingFormViewModel LinkStyling { get; set; } = new();
    public ImageFormViewModel ImageStyling { get; set; } = new();

    public PageDto ToPageDto(int pageId) => new()
    {
        Id = pageId,
        Title = Title
    };

    public CreateTextDto ToTextDto(int pageId) => new()
    {
        PageId = pageId,
        TextContent = TextContent ?? string.Empty,
        CssClass = TextStyling.GetCss()
    };

    public CreateImageDto ToImageDto(int pageId, string imageUrl) => new()
    {
        PageId = pageId,
        ImageUrl = imageUrl,
        CssClass = ImageStyling.GetCss()
    };

    public CreateLinkDto ToLinkDto(int pageId) => new()
    {
        PageId = pageId,
        LinkUrl = LinkUrl!,
        LinkText = string.IsNullOrWhiteSpace(LinkText) ? LinkUrl! : LinkText,
        CssClass = LinkStyling.GetCss()
    };
}
