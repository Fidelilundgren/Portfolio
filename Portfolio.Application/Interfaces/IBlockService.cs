using Portfolio.Application.Dtos;

namespace Portfolio.Application.Interfaces;

public interface IBlockService
{
    Task<List<BlockDto>> GetAllAsync();
    Task<BlockDto?> GetByIdAsync(int id);
    Task<List<BlockDto>> GetByPageIdAsync(int pageId);
    Task AddAsync(BlockDto block);
    Task AddHeadingAsync(CreateHeadingDto headingDto);
    Task UpdateAsync(BlockDto block);
    Task DeleteAsync(int id);
    Task<BlockDto?> GetHeadingByPageIdAsync(int pageId);
    Task AddTextAsync(CreateTextDto createTextDto);
    Task<List<BlockDto>> GetTextsByPageIdAsync(int pageId);
}
