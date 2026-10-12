using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;
namespace Portfolio.Infrastructure.Repositories;

public class BlockRepository : IBlockRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public BlockRepository(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Block>> GetAllAsync()
    {
        using var context = await _factory.CreateDbContextAsync();

        return await context
            .Blocks
            .OrderBy(b => b.Order).ToListAsync();
    }
    public async Task<Block?> GetByIdAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();

        return await context.Blocks.FindAsync(id);
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

    public async Task UpdateAsync(Block block)
    {
        using var context = await _factory.CreateDbContextAsync();

        context.Blocks.Update(block);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();
        var item = await context.Blocks.FindAsync(id);

        if (item != null)
        {
            context.Blocks.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
