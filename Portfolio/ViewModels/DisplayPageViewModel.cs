using Portfolio.Application.Dtos;

namespace Portfolio.ViewModels;

public class DisplayPageViewModel
{
    public PageDto? Page { get; set; }
    public BlockDto? Heading { get; set; }
    public List<BlockDto> Texts { get; set; } = []; 
}
