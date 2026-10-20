namespace Portfolio.ViewModels;

public class ImageFormViewModel
{
    public string? Size { get; set; }
    public string? Placement { get; set; }
    public string? Shape { get; set; }

    public string GetCss()
    {
        var classes = new List<string?>
        {
            Size, Placement, Shape
        };

        return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
    }

    public void LoadFromCss(string? css)
    {
        var classes = (css ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Size = classes.FirstOrDefault(c => c.StartsWith("img-size-"));
        Placement = classes.FirstOrDefault(c => c.StartsWith("img-place-"));
        Shape = classes.FirstOrDefault(c => c.StartsWith("img-shape-"));
    }
}
