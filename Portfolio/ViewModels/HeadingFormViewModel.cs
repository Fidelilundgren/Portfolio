namespace Portfolio.ViewModels;

public class HeadingFormViewModel
{
    public string? FontFamily { get; set; }
    public string? FontSize { get; set; }
    public bool IsBold { get; set; }
    public bool IsItalic { get; set; }
    public string? Alignment { get; set; }
    public string? TextColor { get; set; }

    public string GetCss()
    {
        var classes = new List<string?> { FontFamily, FontSize, Alignment, TextColor };

        if (IsBold)
        {
            classes.Add("fw-bold");
        }
        if (IsItalic)
        {
            classes.Add("fst-italic");
        }

        return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
    }
}
