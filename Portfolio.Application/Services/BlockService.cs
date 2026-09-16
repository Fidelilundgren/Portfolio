using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Services;

public class BlockService : IBlockService
{
    private readonly IBlockRepository _blockRepository;
    public BlockService(IBlockRepository blockRepository)
    {
        _blockRepository = blockRepository;
    }

    public async Task<List<Block>> GetAllAsync()
        => await _blockRepository.GetAllAsync();

    public async Task<Block?> GetByIdAsync(int id)
        => await _blockRepository.GetByIdAsync(id);

    public async Task<List<Block>> GetByPageIdAsync(int pageId)
        => await _blockRepository.GetByPageIdAsync(pageId);

    public async Task AddAsync(Block block)
        => await _blockRepository.AddAsync(block);

    public async Task DeleteAsync(int id)
        => await _blockRepository.DeleteAsync(id);

    public async Task UpdateAsync(Block block)
        => await _blockRepository.UpdateAsync(block);
}
