using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos;

public class PageDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Page name is required")]
    public string Title { get; set; } = string.Empty;
    public int VisitCount { get; set; }
}
