using Portfolio.Application.Dtos;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<List<MenuDto>> GetAllAsync()
    {
        var menus = await _menuRepository.GetAllAsync();

        return menus.Select(m => new MenuDto
        {
            Id = m.Id,
            Title = m.Title,
            Order = m.Order,
            PageId = m.PageId,
        }).ToList();
    }

    public async Task AddAsync(MenuDto menuDto)
    {
        var menus = await _menuRepository.GetAllAsync();

        var menu = new Menu
        {
            Title = menuDto.Title,
            PageId = menuDto.PageId,
            Order = menus.Count
        };

        await _menuRepository.AddAsync(menu);
    }

    public async Task UpdateAsync(MenuDto menuDto)
    {
        var menu = await _menuRepository.GetByIdAsync(menuDto.Id);

        if (menu != null)
        {
            menu.Title = menuDto.Title;
            menu.PageId = menuDto.PageId;

            await _menuRepository.UpdateAsync(menu);
        }
    }

    private async Task SaveOrderAsync(List<Menu> menus)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].Order = i;
            await _menuRepository.UpdateAsync(menus[i]);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _menuRepository.DeleteAsync(id);

        var menus = await _menuRepository.GetAllAsync();
        await SaveOrderAsync(menus);
    }

    public async Task MoveAsync(int id, int direction)
    {
        var menus = await _menuRepository.GetAllAsync();
        int index = menus.FindIndex(m => m.Id == id);
        int newIndex = index + direction;

        if (index == -1 || newIndex < 0 || newIndex >= menus.Count)
        {
            return;
        }

        (menus[index], menus[newIndex]) = (menus[newIndex], menus[index]);
        await SaveOrderAsync(menus);
    }
}
