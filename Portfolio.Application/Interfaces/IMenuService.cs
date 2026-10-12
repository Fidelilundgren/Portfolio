using Portfolio.Application.Dtos;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Interfaces;

public interface IMenuService
{
    Task<List<MenuDto>> GetAllAsync();
    Task AddAsync(MenuDto menuDto);
    Task UpdateAsync(MenuDto menuDto);
    Task DeleteAsync(int id);
    Task MoveAsync(int id, int direction);
}
