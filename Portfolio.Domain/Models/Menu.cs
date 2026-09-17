namespace Portfolio.Domain.Models;

public class Menu
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Order {  get; set; }
    public int PageId { get; set; }

    public Page? Page { get; set; }
}
