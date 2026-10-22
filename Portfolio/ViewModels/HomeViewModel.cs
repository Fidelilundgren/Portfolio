using Portfolio.Application.Dtos;

namespace Portfolio.ViewModels;

public class HomeViewModel
{
    public List<PageDto> Pages { get; set; } = [];

    public Dictionary<int, PageContentDto> PageContents { get; set; } = [];

    public string? GetImageUrl(int pageId)
    {
        if (PageContents.TryGetValue(pageId, out var content)
            && !string.IsNullOrWhiteSpace(content.ImageUrl))
        {
            return content.ImageUrl;
        }

        return null;
    }
}