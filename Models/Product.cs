using System.ComponentModel.DataAnnotations;

namespace UdemyReservationAppServer.Models
{
  public class Product
  {
    public int Id { get; set; }

    public string? CoverImage { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(60, ErrorMessage = "最大60文字までです！")]
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Heading1 { get; set; }
    public string? Heading2 { get; set; }
    public string? Heading3 { get; set; }

    public string? HeadingText1 { get; set; }
    public string? HeadingText2 { get; set; }
    public string? HeadingText3 { get; set; }
  }
}
