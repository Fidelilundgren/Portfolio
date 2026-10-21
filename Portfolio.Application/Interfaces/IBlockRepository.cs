using Portfolio.Domain.Models;

namespace Portfolio.Application.Interfaces;

public interface IBlockRepository
{
    Task<List<Block>> GetByPageIdAsync(int pageId);
    Task AddAsync(Block block);
    Task DeleteByPageIdAsync(int pageId);
}
