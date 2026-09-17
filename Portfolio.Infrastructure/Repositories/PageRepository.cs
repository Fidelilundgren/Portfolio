using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Repositories;

public class PageRepository : IPageRepository
{
    private readonly AppDbContext _context;
    public PageRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<List<Page>> GetAllAsync()
        => await _context.Pages
        .ToListAsync();

    public async Task<Page?> GetByIdAsync(int id)
        => await _context.Pages
        .SingleOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Page page)
    {
        _context.Pages.Add(page);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Page page)
    {
        _context.Pages.Update(page);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Pages.FindAsync(id);

        if (item != null)
        {
            _context.Pages.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
