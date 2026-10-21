using Portfolio.Application.Dtos;

namespace Portfolio.Application.Interfaces;

public interface IMenuService
{
    Task<List<MenuDto>> GetAllAsync();
    Task AddAsync(MenuDto menuDto);
    Task UpdateAsync(MenuDto menuDto);
    Task DeleteAsync(int id);
    Task MoveAsync(int id, int direction);
    Task<bool> IsPageInMenuAsync(int pageId);
    Task SetPageInMenuAsync(MenuDto menuDto, bool showInMenu);
}
