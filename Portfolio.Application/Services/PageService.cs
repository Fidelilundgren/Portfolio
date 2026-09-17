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

    public async Task<List<Page>> GetAllAsync()
        => await _pageRepository.GetAllAsync();

    public async Task<Page?> GetByIdAsync(int id)
        => await _pageRepository.GetByIdAsync(id);

    public async Task AddAsync(Page page)
        => await _pageRepository.AddAsync(page);

    public async Task UpdateAsync(Page page)
        => await _pageRepository.UpdateAsync(page);

    public async Task DeleteAsync(int id)
        => await _pageRepository.DeleteAsync(id);
}
