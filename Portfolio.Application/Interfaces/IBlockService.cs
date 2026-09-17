using Portfolio.Domain.Models;

namespace Portfolio.Application.Interfaces;

public interface IBlockService
{
    Task<List<Block>> GetAllAsync();
    Task<Block?> GetByIdAsync(int id);
    Task<List<Block>> GetByPageIdAsync(int pageId);
    Task AddAsync(Block block);
    Task UpdateAsync(Block block);
    Task DeleteAsync(int id);
}
