using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }
    
    public DbSet<ApplicationUser> Users { get; set; }
    
    public DbSet<Inventory> Inventory { get; set; }
}
