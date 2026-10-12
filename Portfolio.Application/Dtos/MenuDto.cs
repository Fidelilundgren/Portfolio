namespace Portfolio.Application.Dtos;

public class MenuDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Order { get; set; }
    public int PageId { get; set; }
}
