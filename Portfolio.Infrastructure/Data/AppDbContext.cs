using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Portfolio.Infrastructure.Data;
public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Menu> Menus { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Block> Blocks { get; set; }
}
