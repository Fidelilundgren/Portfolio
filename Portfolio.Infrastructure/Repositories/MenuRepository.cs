using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;
    public MenuRepository(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        using var context = await _factory.CreateDbContextAsync();
        
        return await context.Menus
        .OrderBy(m => m.Order)
        .ToListAsync();
    }


    public async Task<Menu?> GetByIdAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();

        return await context
            .Menus
            .FindAsync(id);
    }

    public async Task AddAsync(Menu menu)
    {
        using var context = await _factory.CreateDbContextAsync();

        context.Menus.Add(menu);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        using var context = await _factory.CreateDbContextAsync();

        context.Menus.Update(menu);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = await _factory.CreateDbContextAsync();

        var item = await context.Menus.FindAsync(id);
        if (item != null)
        {
            context.Menus.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
