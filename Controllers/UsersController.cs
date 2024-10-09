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
    public async Task<ActionResult<User>> PostUser(User user)
    {
      var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

      if (!await Validate(user))
      {
        return BadRequest(_errorMessages.ToArray());
      }

      user.Password = _passwordHasher.HashPassword(user, user.Password);

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    private async Task<bool> Validate(User user)
    {
      var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

      if (existingUser != null)
      {
        _errorMessages.Add("このEメールはすでに登録されています。");
      }

      return _errorMessages.Count == 0;
    }
  }
}
