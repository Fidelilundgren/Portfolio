using Portfolio.Application.Dtos;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Services;

public class PageService : IPageService
{
    private readonly IPageRepository _pageRepository;
    private readonly IBlockRepository _blockRepository;
    public PageService(IPageRepository pageRepository, IBlockRepository blockRepository)
    {
        _pageRepository = pageRepository;
        _blockRepository = blockRepository;
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

    public async Task<PageContentDto?> GetContentAsync(int pageId)
    {
        var page = await _pageRepository.GetByIdAsync(pageId);

        if (page == null)
        {
            return null;
        }

        var blocks = await _blockRepository.GetByPageIdAsync(pageId);

        var heading = blocks.FirstOrDefault(b => b.Type == BlockType.Heading);
        var text = blocks.FirstOrDefault(b => b.Type == BlockType.Text);
        var image = blocks.FirstOrDefault(b => b.Type == BlockType.Image);
        var link = blocks.FirstOrDefault(b => b.Type == BlockType.Link);

        return new PageContentDto
        {
            PageId = page.Id,
            Title = page.Title,

            HeadingText = heading?.TextContent ?? string.Empty,
            HeadingCss = heading?.CssClass,

            Text = text?.TextContent,
            TextCss = text?.CssClass,

            ImageUrl = image?.ImageUrl,
            ImageCss = image?.CssClass,

            LinkUrl = link?.LinkUrl,
            LinkText = link?.LinkText,
            LinkCss = link?.CssClass
        };
    }

    public async Task<int> CreateContentAsync(PageContentDto dto)
    {
        var page = new Page
        {
            Title = dto.Title
        };

        await _pageRepository.AddAsync(page); 
        await AddBlocksAsync(page.Id, dto);

        return page.Id;
    }

    public async Task UpdateContentAsync(PageContentDto dto)
    {
        var page = await _pageRepository.GetByIdAsync(dto.PageId);

        if (page == null)
        {
            return;
        }

        page.Title = dto.Title;
        await _pageRepository.UpdateAsync(page);

        await _blockRepository.DeleteByPageIdAsync(dto.PageId);
        await AddBlocksAsync(dto.PageId, dto);
    }

    public async Task DeleteAsync(int id)
        => await _pageRepository.DeleteAsync(id);

    public async Task VisitCountAsync(int id)
        => await _pageRepository.VisitCountAsync(id);

    private async Task AddBlocksAsync(int pageId, PageContentDto dto)
    {
        await _blockRepository.AddAsync(new Block
        {
            PageId = pageId,
            Type = BlockType.Heading,
            Order = 0,
            TextContent = dto.HeadingText,
            CssClass = dto.HeadingCss
        });

        if (!string.IsNullOrWhiteSpace(dto.Text))
        {
            await _blockRepository.AddAsync(new Block
            {
                PageId = pageId,
                Type = BlockType.Text,
                Order = 1,
                TextContent = dto.Text,
                CssClass = dto.TextCss
            });
        }

        if (!string.IsNullOrWhiteSpace(dto.ImageUrl))
        {
            await _blockRepository.AddAsync(new Block
            {
                PageId = pageId,
                Type = BlockType.Image,
                Order = 2,
                ImageUrl = dto.ImageUrl,
                CssClass = dto.ImageCss
            });
        }

        if (!string.IsNullOrWhiteSpace(dto.LinkUrl))
        {
            await _blockRepository.AddAsync(new Block
            {
                PageId = pageId,
                Type = BlockType.Link,
                Order = 3,
                LinkUrl = dto.LinkUrl,
                LinkText = dto.LinkText,
                CssClass = dto.LinkCss
            });
        }
    }
}
