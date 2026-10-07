using Portfolio.Application.Dtos;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Services;

public class PageService : IPageService
{
    private readonly IPageRepository _pageRepository;
    public PageService(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }

    public async Task<List<PageDto>> GetAllAsync()
    {
        var pages = await _pageRepository.GetAllAsync();

        return pages.Select(p => new PageDto 
        { 
            Id = p.Id, 
            Title = p.Title, 
            VisitCount = p.VisitCount 
        }).ToList();
    }

    public async Task<PageDto?> GetByIdAsync(int id)
    {
        var page = await _pageRepository.GetByIdAsync(id);

        if (page == null)
        {
            return null;
        }

        return new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            VisitCount = page.VisitCount
        };
    }

    public async Task<int> AddAsync(PageDto pageDto)
    {
        var page = new Page
        {
            Title = pageDto.Title
        };

        await _pageRepository.AddAsync(page);

        return page.Id;
    }

    public async Task UpdateAsync(PageDto pageDto)
    {
        var page = await _pageRepository.GetByIdAsync(pageDto.Id);

        if (page != null)
        {
            page.Title = pageDto.Title;
            await _pageRepository.UpdateAsync(page);
        }
    }

    public async Task DeleteAsync(int id)
        => await _pageRepository.DeleteAsync(id);
}
