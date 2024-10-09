using System.ComponentModel.DataAnnotations;

namespace UdemyReservationAppServer.Models
{
  public class User
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "ユーザー名は必須です！")]
    [MaxLength(60, ErrorMessage = "ユーザー名は最大60文字までです！")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Eメールは必須です！")]
    [MaxLength(60, ErrorMessage = "Eメールは最大60文字までです！")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "パスワードは必須です！")]
    [MinLength(6, ErrorMessage = "パスワードは6文字以上で入力してください！")]
    [MaxLength(30, ErrorMessage = "パスワードは最大30文字までです！")]
    public string Password { get; set; } = string.Empty;
  }
}
