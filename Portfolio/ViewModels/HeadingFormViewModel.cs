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
            classes.Add("bold");
        }
        if (IsItalic)
        {
            classes.Add("italic");
        }

        return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
    }

    public void LoadFromCss(string? css)
    {
        var classes = (css ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

        FontFamily = classes.FirstOrDefault(c => c.StartsWith("font-"));
        FontSize = classes.FirstOrDefault(c => c.StartsWith("size-"));
        Alignment = classes.FirstOrDefault(c => c.StartsWith("align-"));
        TextColor = classes.FirstOrDefault(c => c.StartsWith("color-"));
        IsBold = classes.Contains("bold");
        IsItalic = classes.Contains("italic");
    }
}
