using Microsoft.AspNetCore.Components.Forms;
using Portfolio.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels;

public class PageFormViewModel
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(10, ErrorMessage = "Title can contain maximum 10 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heading is required")]
    [StringLength(20, ErrorMessage = "Heading can contain maximum 20 characters")]
    public string HeadingText { get; set; } = string.Empty;

    [StringLength(5000, ErrorMessage = "Text can contain maximum 5000 character")]
    public string? Text { get; set; }

    private string? _linkUrl;

    [Url(ErrorMessage = "Must be a valid URL")]
    public string? LinkUrl
    {
        get => _linkUrl;
        set => _linkUrl = string.IsNullOrWhiteSpace(value) ? null : value;
    }

    [StringLength(50, ErrorMessage = "Link text can contain maximum 50 characters")]
    public string? LinkText { get; set; }

    public bool AddToMenu { get; set; } = true;

    // Image
    public IBrowserFile? UploadedImage { get; set; }
    public string? ImageError { get; set; }
    public string? ImageUrl { get; set; }
    public bool RemoveImage { get; set; }

    // Styling
    public HeadingFormViewModel HeadingStyling { get; set; } = new();
    public HeadingFormViewModel TextStyling { get; set; } = new();
    public HeadingFormViewModel LinkStyling { get; set; } = new();
    public ImageFormViewModel ImageStyling { get; set; } = new();

    public PageContentDto ToDto(int pageId = 0) => new()
    {
        PageId = pageId,
        Title = Title,
        HeadingText = HeadingText,
        HeadingCss = HeadingStyling.GetCss(),
        Text = Text,
        TextCss = TextStyling.GetCss(),
        ImageUrl = ImageUrl,
        ImageCss = ImageStyling.GetCss(),
        LinkUrl = LinkUrl,
        LinkText = string.IsNullOrWhiteSpace(LinkText) ? LinkUrl : LinkText,
        LinkCss = LinkStyling.GetCss()
    };

    public MenuDto ToMenuDto(int pageId) => new()
    {
        Title = Title,
        PageId = pageId
    };

    public void LoadFrom(PageContentDto dto)
    {
        Title = dto.Title;
        HeadingText = dto.HeadingText;
        HeadingStyling.LoadFromCss(dto.HeadingCss);
        Text = dto.Text;
        TextStyling.LoadFromCss(dto.TextCss);
        ImageUrl = dto.ImageUrl;
        ImageStyling.LoadFromCss(dto.ImageCss);
        UploadedImage = null;
        RemoveImage = false;
        LinkUrl = dto.LinkUrl;
        LinkText = dto.LinkText;
        LinkStyling.LoadFromCss(dto.LinkCss);
    }
}
