using UdemyReservationAppServer.Data;
using UdemyReservationAppServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace UdemyReservationAppServer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private List<string> _errorMessages = new List<string>();

    public UsersController(UserDbContext context)
    {
      _context = context;
      _passwordHasher = new PasswordHasher<User>();
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      return await _context.Users.ToListAsync();
    }

    // GET: api/users/[id]
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
      var user = await _context.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    // POST: api/register
    [HttpPost("/api/register")]
    public async Task<ActionResult<User>> RegistUser(User user)
    {
      if (!await RegistValidate(user))
      {
        return BadRequest(_errorMessages.ToArray());
      }

      user.Password = _passwordHasher.HashPassword(user, user.Password);

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    private async Task<bool> RegistValidate(User user)
    {
      var userInfo = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
      if (userInfo != null)
      {
        _errorMessages.Add("このEメールはすでに登録されています。");
      }

      return _errorMessages.Count == 0;
    }

    // POST: api/login
    [HttpPost("/api/login")]
    public async Task<ActionResult<User>> LoginUser(User user)
    {
      if (!await LoginValidate(user))
      {
        return BadRequest(_errorMessages.ToArray());
      }

      var obj = new List<string>() { "ログイン成功！" };

      return Ok(obj);
    }

    private async Task<bool> LoginValidate(User user)
    {
      var userInfo = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
      if (userInfo == null)
      {
        _errorMessages.Add("ユーザーが見つかりません。");
        return _errorMessages.Count == 0;
      }

      if (!VerifyPassword(userInfo, user))
      {
        _errorMessages.Add("パスワードが一致しません。");
      }

      return _errorMessages.Count == 0;
    }

    private bool VerifyPassword(User userInfo, User user)
    {
      var verificationResult = _passwordHasher.VerifyHashedPassword(userInfo, userInfo.Password, user.Password);

      return verificationResult == PasswordVerificationResult.Success;
    }
  }
}
