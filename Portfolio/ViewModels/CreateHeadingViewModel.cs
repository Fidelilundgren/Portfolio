using Portfolio.Application.Dtos;

namespace Portfolio.ViewModels;

public class CreateHeadingViewModel
{
    public CreateHeadingDto Heading { get; set; } = new();
    public string? FontFamily { get; set; }
    public string? FontSize { get; set; }
    public bool IsBold { get; set; }
    public  bool IsItalic { get; set; }
    public string? Alignment { get; set; }
    public string? TextColor { get; set; }
}
