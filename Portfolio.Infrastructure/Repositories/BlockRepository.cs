using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;
using Portfolio.Infrastructure.Data;
namespace Portfolio.Infrastructure.Repositories;

public class BlockRepository : IBlockRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public BlockRepository(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Block>> GetByPageIdAsync(int pageId)
    {
        using var context = await _factory.CreateDbContextAsync();

        return await context.Blocks
        .Where(b => b.PageId == pageId)
        .OrderBy(b => b.Order)
        .ToListAsync();
    }

    public async Task AddAsync(Block block)
    {
        using var context = await _factory.CreateDbContextAsync();

        context.Blocks.Add(block);
        await context.SaveChangesAsync();
    }

    public async Task DeleteByPageIdAsync(int pageId)
    {
        using var context = await _factory.CreateDbContextAsync();
        await context.Blocks.Where(b => b.PageId == pageId).ExecuteDeleteAsync();
    }
}
