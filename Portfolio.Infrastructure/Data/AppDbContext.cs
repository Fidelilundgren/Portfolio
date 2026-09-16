using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Menu> Menus { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Block> Blocks { get; set; }
}
