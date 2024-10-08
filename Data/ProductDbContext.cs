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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // シードデータの追加
      modelBuilder.Entity<Product>().HasData(
          new Product
          {
            Id = 1,
            CoverImage = "./assets/img/phone-cover.jpg",
            Name = "Phone XL",
            Price = 799,
            Description = "A large phone with one of the best screens",
            Heading1 = "Edge-to-Edge Display",
            Heading2 = "Facial recognition",
            Heading3 = "Powerful chip",
            HeadingText1 = "The Phone XL introduced a 5.8-inch display with minimal bezels, offering an immersive viewing experience and vibrant colors.",
            HeadingText2 = "It was the first Phone to replace the fingerprint sensor with facial recognition technology for unlocking the phone and authentication.",
            HeadingText3 = "The Phone XL featured powerful chip, which enhanced performance, efficiency, and supported advanced augmented reality (AR) applications."
          },
          new Product
          {
            Id = 2,
            CoverImage = "./assets/img/phone-cover.jpg",
            Name = "Phone Mini",
            Price = 699,
            Description = "A great phone with one of the best cameras",
            Heading1 = "Phone Mini heading1",
            Heading2 = "Phone Mini heading2",
            Heading3 = "Phone Mini heading3",
            HeadingText1 = "Phone Mini headingText1",
            HeadingText2 = "Phone Mini headingText2",
            HeadingText3 = "Phone Mini headingText3"
          },
          new Product
          {
            Id = 3,
            CoverImage = "./assets/img/phone-cover.jpg",
            Name = "Phone Standard",
            Price = 299,
            Description = "",
            Heading1 = "Phone Standard heading1",
            Heading2 = "Phone Standard heading2",
            Heading3 = "Phone Standard heading3",
            HeadingText1 = "Phone Standard headingText1",
            HeadingText2 = "Phone Standard headingText2",
            HeadingText3 = "Phone Standard headingText3"
          },
          new Product
          {
            Id = 4,
            CoverImage = "./assets/img/phone-cover.jpg",
            Name = "Phone Special",
            Price = 900,
            Description = "",
            Heading1 = "Phone Special heading1",
            Heading2 = "Phone Special heading2",
            Heading3 = "Phone Special heading3",
            HeadingText1 = "Phone Special headingText1",
            HeadingText2 = "Phone Special headingText2",
            HeadingText3 = "Phone Special headingText3"
          }
      );
    }
  }
}
