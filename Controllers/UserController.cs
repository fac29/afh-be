using afh_be.Data;
using afh_be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly MovieDBContext _context;

        public UsersController(MovieDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // [HttpPost]
        // public async IEnumerable<User> AddUser(User user)
        // {
        //     await _context.Users.Add(User);
        //     await _context.SaveChangesAsync();
        //     return IAsyncEnumerator<User>;
        // }
    }
}
