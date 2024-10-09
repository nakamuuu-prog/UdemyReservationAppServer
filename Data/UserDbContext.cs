using Microsoft.EntityFrameworkCore;
using UdemyReservationAppServer.Models;

namespace UdemyReservationAppServer.Data
{
  public class UserDbContext : DbContext
  {
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=users.db");
    }
  }
}
