using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class PageRepository : IPageRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public PageRepository(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }
    public async Task<List<Page>> GetAllAsync()
    {
        using var context = await _factory.CreateDbContextAsync();

        return await context.Pages.OrderBy(p => p.Id).ToListAsync();
    }

    public async Task<Page?> GetByIdAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();

        return await context.Pages.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Page page)
    {
        using var context = await _factory.CreateDbContextAsync();

        context.Pages.Add(page);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Page page)
    {
        using var context = await _factory.CreateDbContextAsync();

        context.Pages.Update(page);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();
        var item = await context.Pages.FindAsync(id);

        if (item != null)
        {
            context.Pages.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
