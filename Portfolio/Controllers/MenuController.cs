using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Dtos;
using Portfolio.Application.Interfaces;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/Menu")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<List<MenuDto>> GetAllMenuItems()
    {
        return await _menuService.GetAllAsync();
    }

}
