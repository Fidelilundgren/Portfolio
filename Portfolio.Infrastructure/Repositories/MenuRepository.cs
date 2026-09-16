using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;
    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Menu>> GetAllAsync() 
        => await _context.Menus
        .OrderBy(m => m.Order)
        .ToListAsync();

    public async Task<Menu?> GetByIdAsync(int id)
        => await _context.Menus
        .FindAsync(id);

    public async Task AddAsync(Menu menu)
    {
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Menus.FindAsync(id);
        if (item != null)
        {
            _context.Menus.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    

   

    public Task UpdateAsync(Menu menu)
    {
        throw new NotImplementedException();
    }
}
