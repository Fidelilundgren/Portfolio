using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<List<Menu>> GetAllAsync()
        => await _menuRepository.GetAllAsync();

    public async Task<Menu?> GetByIdAsync(int id)
        => await _menuRepository.GetByIdAsync(id);

    public async Task AddAsync(Menu menu)
        => await _menuRepository.AddAsync(menu);

    public async Task UpdateAsync(Menu menu)
        => await _menuRepository.UpdateAsync(menu);

    public async Task DeleteAsync(int id)
        => await _menuRepository.DeleteAsync(id);
    
}
