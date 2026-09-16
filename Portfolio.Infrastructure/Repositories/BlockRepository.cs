using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories;

public class BlockRepository : IBlockRepository
{
    private readonly AppDbContext _context;
    public BlockRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    public async Task<List<Block>> GetAllAsync()
        => await _context.Blocks
        .OrderBy(b => b.Order)
        .ToListAsync();

    public async Task<Block?> GetByIdAsync(int id)
        => await _context.Blocks
        .FindAsync(id);

    public async Task<List<Block>> GetByPageIdAsync(int pageId)
        => await _context.Blocks
        .Where(b => b.PageId == pageId)
        .OrderBy(b => b.Order)
        .ToListAsync();

    public async Task AddAsync(Block block)
    {
        _context.Blocks.Add(block);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Block block)
    {
        _context.Blocks.Update(block);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Blocks.FindAsync(id);

        if (item != null)
        {
            _context.Blocks.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
    

    

    
}
