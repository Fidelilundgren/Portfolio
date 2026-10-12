using Portfolio.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels;

public class MenuViewModel
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Choose a page")]
    public int PageId { get; set; }

    public List<MenuDto> MenuItems { get; set; } = [];
    public List<PageDto> Pages { get; set; } = [];

    public MenuDto ToMenuDto() => new()
    {
        Title = Title,
        PageId = PageId,
    };

    public string GetPageTitle(int pageId)
        => Pages.FirstOrDefault(p => p.Id == pageId)?.Title ?? "Page missing";
}
