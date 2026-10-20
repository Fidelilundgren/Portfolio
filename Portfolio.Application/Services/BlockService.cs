using Portfolio.Application.Dtos;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Models;

namespace Portfolio.Application.Services;

public class BlockService : IBlockService
{
    private readonly IBlockRepository _blockRepository;
    public BlockService(IBlockRepository blockRepository)
    {
        _blockRepository = blockRepository;
    }

    public async Task<List<BlockDto>> GetAllAsync()
    {
        var blocks = await _blockRepository.GetAllAsync();

        return blocks.Select(b => new BlockDto 
        { 
            Id = b.Id, 
            Type = b.Type,
            Order = b.Order, 
            TextContent = b.TextContent, 
            ImageUrl = b.ImageUrl, 
            LinkUrl = b.LinkUrl, 
            LinkText = b.LinkText,
            CssClass = b.CssClass,
            PageId = b.PageId
        }).ToList();
    }

    public async Task<BlockDto?> GetByIdAsync(int id)
    {
        var block = await _blockRepository.GetByIdAsync(id);

        if (block == null)
        {
            return null;
        }
        return new BlockDto
        {
            Id = block.Id,
            Type = block.Type,
            Order = block.Order,
            TextContent = block.TextContent,
            ImageUrl = block.ImageUrl,
            LinkUrl = block.LinkUrl,
            LinkText = block.LinkText,
            CssClass = block.CssClass,
            PageId = block.PageId
        };
    }

    public async Task<List<BlockDto>> GetByPageIdAsync(int pageId)
    {
        var blocks = await _blockRepository.GetByPageIdAsync(pageId);

        return blocks.Select(b => new BlockDto
        {
            Id = b.Id,
            Type = b.Type,
            Order = b.Order,
            TextContent = b.TextContent,
            ImageUrl = b.ImageUrl,
            LinkUrl = b.LinkUrl,
            LinkText = b.LinkText,
            CssClass = b.CssClass,
            PageId = b.PageId
        }).ToList();
    }

    public async Task AddAsync(BlockDto blockDto)
    {
        var block = new Block
        {
            Type = blockDto.Type,
            Order = blockDto.Order,
            TextContent = blockDto.TextContent,
            ImageUrl = blockDto.ImageUrl,
            LinkUrl = blockDto.LinkUrl,
            LinkText = blockDto.LinkText,
            CssClass = blockDto.CssClass,
            PageId = blockDto.PageId
        };

        await _blockRepository.AddAsync(block);
    }

    public async Task AddHeadingAsync(CreateHeadingDto headingDto)
    {
        var block = new Block
        {
            Type = BlockType.Heading,
            PageId = headingDto.PageId,
            TextContent = headingDto.TextContent,
            Order = headingDto.Order,
            CssClass = headingDto.CssClass
        };

        await _blockRepository.AddAsync(block);
    }

    public async Task UpdateAsync(BlockDto blockDto)
    {
        var block = await _blockRepository.GetByIdAsync(blockDto.Id);

        if (block != null)
        {
            block.Type = blockDto.Type;
            block.Order = blockDto.Order;
            block.TextContent = blockDto.TextContent;
            block.ImageUrl = blockDto.ImageUrl;
            block.LinkUrl = blockDto.LinkUrl;
            block.LinkText = blockDto.LinkText;
            block.CssClass = blockDto.CssClass;
            block.PageId = blockDto.PageId;

            await _blockRepository.UpdateAsync(block);
        }
    }

    public async Task DeleteAsync(int id)
        => await _blockRepository.DeleteAsync(id);

    public async Task<BlockDto?> GetHeadingByPageIdAsync(int pageId)
    {
        var blocks = await GetByPageIdAsync(pageId);
        return blocks.FirstOrDefault(b => b.Type == BlockType.Heading);
    }

    public async Task AddTextAsync(CreateTextDto createTextDto)
    {
        var block = new Block
        {
            Type = BlockType.Text,
            PageId = createTextDto.PageId,
            TextContent = createTextDto.TextContent,
            CssClass = createTextDto.CssClass
        };

        await _blockRepository.AddAsync(block);
    }

    public async Task<List<BlockDto>> GetTextsByPageIdAsync(int pageId)
    {
        var blocks = await GetByPageIdAsync(pageId);

        return blocks
            .Where(b => b.Type == BlockType.Text)
            .OrderByDescending(b => b.Id)
            .ToList();
    }

    public async Task AddImageAsync(CreateImageDto createImageDto)
    {
        var block = new Block
        {
            Type = BlockType.Image,
            PageId = createImageDto.PageId,
            ImageUrl = createImageDto.ImageUrl,
            CssClass = createImageDto.CssClass
        };

        await _blockRepository.AddAsync(block);
    }

    public async Task<BlockDto?> GetImageByPageIdAsync(int pageId)
    {
        var blocks = await GetByPageIdAsync(pageId);
        return blocks.FirstOrDefault(b => b.Type == BlockType.Image);
    }

    public async Task AddLinkAsync(CreateLinkDto createLinkDto)
    {
        var block = new Block
        {
            Type = BlockType.Link,
            PageId = createLinkDto.PageId,
            LinkUrl = createLinkDto.LinkUrl,
            LinkText = createLinkDto.LinkText,
            CssClass = createLinkDto.CssClass
        };

        await _blockRepository.AddAsync(block);
    }

    public async Task<BlockDto?> GetLinkByPageIdAsync(int pageId)
    {
        var blocks = await GetByPageIdAsync(pageId);
        return blocks.FirstOrDefault(b => b.Type == BlockType.Link);
    }
}
