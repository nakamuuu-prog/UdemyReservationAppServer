using Microsoft.EntityFrameworkCore;
using UdemyReservationAppServer.Models;

namespace UdemyReservationAppServer.Data
{
  public class ProductDbContext : DbContext
  {
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=products.db");
    }
  }
}
