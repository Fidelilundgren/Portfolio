using Portfolio.Domain.Models;

namespace Portfolio.Application.Interfaces;

public interface IPageRepository
{
    Task<List<Page>> GetAllAsync();
    Task<Page?> GetByIdAsync(int id);
    Task AddAsync(Page page);
    Task UpdateAsync(Page page);
    Task DeleteAsync(int id);
}
