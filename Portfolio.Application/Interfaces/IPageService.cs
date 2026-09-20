using Portfolio.Application.Dtos;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Interfaces;

public interface IPageService
{
    Task<List<PageDto>> GetAllAsync();
    Task<PageDto?> GetByIdAsync(int id);
    Task AddAsync(PageDto dto);
    Task UpdateAsync(PageDto page);
    Task DeleteAsync(int id);
}
