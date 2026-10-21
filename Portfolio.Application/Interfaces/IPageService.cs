using Portfolio.Application.Dtos;

namespace Portfolio.Application.Interfaces;

public interface IPageService
{
    Task<List<PageDto>> GetAllAsync();
    Task<PageContentDto?> GetContentAsync(int pageId);
    Task<int> CreateContentAsync(PageContentDto dto);
    Task UpdateContentAsync(PageContentDto dto);
    Task DeleteAsync(int id);
    Task VisitCountAsync(int id);
}
