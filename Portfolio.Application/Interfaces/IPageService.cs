using Portfolio.Application.Dtos;

namespace Portfolio.Application.Interfaces;

public interface IPageService
{
    Task<List<PageDto>> GetAllAsync();
    Task<PageDto?> GetByIdAsync(int id);
    Task<int> AddAsync(PageDto dto);
    Task UpdateAsync(PageDto page);
    Task DeleteAsync(int id);
    Task VisitCountAsync(int id);
}
