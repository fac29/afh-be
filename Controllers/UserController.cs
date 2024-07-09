using afh_be.Models;
using afh_db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly MovieDBContext _context;
        private readonly IUserLibrary _userLibrary;

        public UsersController(MovieDBContext context, IUserLibrary userLibrary)
        {
            _context = context;
            _userLibrary = userLibrary;
        }

        // Need a database method if we want to get all users - needs to be protected route. 

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> GetUser()
        // {
        //     return await _context.Users.ToListAsync();
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userLibrary.GetUser(id);

            // Return a new user, which keys and vlaues do we want to return?
            var resultUser = new User
            {
                UserID = id,
                Name = user.Name,
            }

            return resultUser;
        
        }

        // Meed to make a database method for AddUser
        // [HttpPost("AddUser")]
        // public async Task AddUser([FromBody] User Object)
        // {
        //     var user = Object;
        //     if (user != null)
        //     {
        //         _context.Users.Add(user);
        //         await _context.SaveChangesAsync();
        //     }
        //     return;
        // }

        // Need a database method to edit user
        [HttpPatch("EditUser{id}")]
        public async Task<IActionResult> EditUser([FromBody] User updatedUser, int id)
        {
            // Find the existing user by id
            var existingUser = await _context.Users.FindAsync(id);

            // Check if the user exists
            if (existingUser == null)
            {
                return NotFound(); // Return 404 Not Found if user with id not found
            }

            // Update the existing user properties with values from updatedUser
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.HashedPassword = updatedUser.HashedPassword;
            // Do not update CreatedAt assuming it should remain the same

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
                return NoContent(); // Return 204 No Content on successful update
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception (optional)
                return StatusCode(500); // Return 500 Internal Server Error or handle differently
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task DeleteUSer(int id)
        {
            await _userLibrary.DeleteUser(id);
        }
    }
}
