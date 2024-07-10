using afh_db;
using afh_db.Libraries;
using afh_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserLibrary _userLibrary;

        public UserController(IUserLibrary userLibrary)
        {
            _userLibrary = userLibrary;
        }

        // Commented out the all route as this could be a security risk
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> GetUser()
        // {
        //     return await _userLibrary.Users.ToListAsync();
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userLibrary.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("Add")]
        public async Task AddUser([FromBody] User user)
        {
            if (user != null)
            {
                await _userLibrary.AddUser(user);
            }
            return;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditUser([FromBody] User updatedUser, int id)
        {
            // Find the existing user by id
            var existingUser = await _userLibrary.GetUserById(id);

            // Check if the user exists
            if (existingUser == null)
            {
                return NotFound(); // Return 404 Not Found if user with id not found
            }

            try
            {
                // Save changes to the database
                await _userLibrary.EditUser(updatedUser);
                return NoContent(); // Return 204 No Content on successful update
            }
            catch (Exception)
            {
                // Handle concurrency exception (optional)
                // Log an error here
                return StatusCode(500); // Return 500 Internal Server Error or handle differently
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userLibrary.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userLibrary.DeleteUser(user);
            return NoContent();
        }
    }
}
